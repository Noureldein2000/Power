using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Power.Core.DTOs;
using Power.Core.Services.Interface;
using Power.Data.Entities;
using Power.Utilities.Helper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Power.Core.Services.Implemenation
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;
        public AuthService(UserManager<User> userManager, IOptions<JWT> jwt,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
            _roleManager = roleManager;
        }

        public async Task<string> AddRolesAsync(AddRoleDTO dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(dto.RoleName))
                return "Invalid user or role";

            if (await _userManager.IsInRoleAsync(user, dto.RoleName))
                return " User is already assigned to this role from develop branch by merged command !";

            var result = await _userManager.AddToRoleAsync(user, dto.RoleName);

            return result.Succeeded ? string.Empty : "There is something wwrong happened";

        }

        public async Task<AuthDTO> GetTokenAsync(TokenRequestDTO dto)
        {

            var authDto = new AuthDTO();
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                authDto.Message = "Email or Password is incorrect ! ";
                return authDto;
            }

            var jwtToken = await CreateJwtToken(user);
            var roles = await _userManager.GetRolesAsync(user);
            authDto.Email = user.Email;
            //ExpireOn = jwtToken.ValidTo,
            authDto.IsAuthenticated = true;
            authDto.Roles = roles.ToList();
            authDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            authDto.Username = user.UserName;

            if (user.RefreshTokens.Any(t => t.IsActive))
            {
                var activedRefreshToken = user.RefreshTokens.FirstOrDefault(x => x.IsActive);
                authDto.RefreshToken = activedRefreshToken.Token;
                authDto.RefreshTokenExpiration = activedRefreshToken.ExpireOn;
            }
            else
            {
                var refreshToken = GenerateRefreshToken();
                authDto.RefreshToken = refreshToken.Token;
                authDto.RefreshTokenExpiration = refreshToken.ExpireOn;
                user.RefreshTokens.Add(refreshToken);
                await _userManager.UpdateAsync(user);
            }

            return authDto;
        }

        public async Task<AuthDTO> RegisterAsync(RegisterDTO dto)
        {
            if (await _userManager.FindByEmailAsync(dto.Email) is not null)
                return new AuthDTO { Message = "Email is already  registered!" };

            var user = new User
            {
                UserName = dto.Username,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                {
                    errors += $"{ error.Description},\n";
                }

                return new AuthDTO { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, "User");
            var jwtToken = await CreateJwtToken(user);
            return new AuthDTO
            {
                Email = user.Email,
                //ExpireOn = jwtToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                Username = user.UserName
            };
        }

        private async Task<JwtSecurityToken> CreateJwtToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim("roles", role));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid",user.Id)
            }.Union(userClaims).Union(roleClaims);

            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredintials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwt.DurationInMintues),
                signingCredentials: signingCredintials
                );

            return jwtSecurityToken;
        }

        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var generator = new RNGCryptoServiceProvider();
            generator.GetBytes(randomNumber);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpireOn = DateTime.UtcNow.AddDays(1),
                CreatedOn = DateTime.UtcNow
            };
        }


    }
}
