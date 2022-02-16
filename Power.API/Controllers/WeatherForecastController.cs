using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IStringLocalizer<PowerResource> _localizer;
        private static readonly string[] Summaries = new[]
        {
             "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IStringLocalizer<PowerResource> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            //throw new PowerException("Failed to get Weather Forecast..!", "-5");
            var rng = new Random();
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                Name = Summaries.Select(nm => _localizer[nm].Value).ToArray()
            })
        .ToArray();

            _logger.LogInformation($"Done Get result Successfully...");
            return result;


        }

        [HttpGet("GetValueLoclizaer")]
        public IActionResult GetValueLoclizaer()
        {
            var name = _localizer["MyName"].Value;
            return Ok(_localizer["Welcome", name].Value);


        }
    }
}
