using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Power.API.Model;
using Power.Core.DTOs;
using Power.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("RegisterAsync")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> GetToken([FromBody] TokenRequestDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            if (!string.IsNullOrEmpty(result.RefreshToken))
                SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);
            return Ok(result);
        }

        [HttpPost("AddRole")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRole([FromBody] AddRoleDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.AddRolesAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(model);
        }

        [HttpGet("ReFreshToken")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> ReFreshToken()
        {
            var refreshToken = Request.Cookies["RefreshToken"];

            var result = await _authService.RefreshTokenAsync(refreshToken);

            if (!result.IsAuthenticated)
                return BadRequest(result);

            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);
            return Ok(result);
        }
        [HttpPost("RevokeToken")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeToken model)
        {
            var token = model.Token ?? Request.Cookies["RefreshToken"];
            if (string.IsNullOrEmpty(token))
                return BadRequest("Token is Required");

            var result = await _authService.RevokeTokenAsync(token);
            if (!result)
                return BadRequest("Token is invalid");

            return Ok(result);
        }

        private void SetRefreshTokenInCookie(string refreshToken, DateTime expireOn)
        {
            var cookieOption = new CookieOptions
            {
                HttpOnly = true,
                Expires = expireOn.ToLocalTime()
            };

            Response.Cookies.Append("RefreshToken", refreshToken, cookieOption);
        }
    }
}
