using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Dz6Filtering.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IConfigurationService _configurationService;
        private readonly IConfiguration _configuration;

        public WeatherForecastController(
            IConfigurationService configurationService)
        {
            _configurationService = configurationService;
            _configuration = configurationService.Configuration;
        }

        // Не зважаючи на порядок, AuthorizationFilter спрацює першим
        [HttpGet]
        [ServiceFilter(typeof(RequestExceptionFilter))]
        [TypeFilter(typeof(RequestAuthorizationFilter))]
        public IEnumerable<WeatherForecast> Get()
        {

            //var rng = new Random();
            Random rng = null;

            if (rng == null)
            {
                throw new NoRandomInstanceException("You can not create weather forecast data, because Random instance == null");
            }

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
