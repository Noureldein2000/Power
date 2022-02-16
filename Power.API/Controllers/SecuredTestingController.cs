using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SecuredTestingController : ControllerBase
    {
        [HttpGet("GetData")]
        public IActionResult GetData()
        {
            return Ok("Hello from Secured controller");
        }
    }
}
