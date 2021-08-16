using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dz5Routing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // ------------------------------------------------------------------

        // http://localhost:5000/WeatherForecast/alpha/hello
        // http://localhost:5000/WeatherForecast/alpha/helloworld/
        [HttpGet]
        [Route("alpha/{customParam:alpha}")]
        public IEnumerable<WeatherForecast> GetAlpha()
        {
            return CreateWeatherForecats();
        }

        // http://localhost:5000/WeatherForecast/bool/true
        // http://localhost:5000/WeatherForecast/bool/false
        [HttpGet]
        [Route("bool/{customParam:bool}")]
        public IEnumerable<WeatherForecast> GetBool()
        {
            return CreateWeatherForecats();
        }


        // http://localhost:5000/WeatherForecast/cust/blue
        // http://localhost:5000/WeatherForecast/cust/green
        [HttpGet]
        [Route("cust/{customParam:cust}")]
        //[Route("cust/{customParam:cust(blue)}")] 
        //[Route("cust/{customParam:cust(green)}")] 
        public IEnumerable<WeatherForecast> GetCust()
        {
            return CreateWeatherForecats();
        }

        // http://localhost:5000/WeatherForecast/datetime/08.28.2014
        // http://localhost:5000/WeatherForecast/datetime/2014-08-28T12:28:30.0000000}
        [HttpGet]
        [Route("datetime/{customParam:datetime}")]
        public IEnumerable<WeatherForecast> GetDateTime()
        {
            return CreateWeatherForecats();
        }

        // http://localhost:5000/WeatherForecast/decimal/12.3
        // http://localhost:5000/WeatherForecast/decimal/10000000000000000000000000000
        [HttpGet]
        [Route("decimal/{customParam:decimal}")]
        public IEnumerable<WeatherForecast> GetDecimal()
        {
            return CreateWeatherForecats();
        }

        // http://localhost:5000/WeatherForecast/double/12.3
        // http://localhost:5000/WeatherForecast/double/133.00110000
        [HttpGet]
        [Route("double/{customParam:double}")]
        public IEnumerable<WeatherForecast> GetDouble()
        {
            return CreateWeatherForecats();
        }

        // http://localhost:5000/WeatherForecast/float/12.3
        // http://localhost:5000/WeatherForecast/float/-133.034
        [HttpGet]
        [Route("float/{customParam:float}")]
        public IEnumerable<WeatherForecast> GetFloat()
        {
            return CreateWeatherForecats();
        }

        // http://localhost:5000/WeatherForecast/guid/7eb34e0a-6c7e-4054-8468-b7080b734c6f
        // http://localhost:5000/WeatherForecast/guid/802efc71-9287-4f89-9dd2-05f5bd347033
        [HttpGet]
        [Route("guid/{customParam:guid}")]
        public IEnumerable<WeatherForecast> GetGuid()
        {
            return CreateWeatherForecats();
        }

        // http://localhost:5000/WeatherForecast/int/1234
        // http://localhost:5000/WeatherForecast/int/-2147483648
        [HttpGet]
        [Route("int/{customParam:int}")]
        public IEnumerable<WeatherForecast> GetInt()
        {
            return CreateWeatherForecats();
        }

        // http://localhost:5000/WeatherForecast/length/34444
        // http://localhost:5000/WeatherForecast/length/hello_m
        [HttpGet]
        [Route("length/{customParam:length(3,7)}")] 
        //[Route("length/{customParam:length(5)}")]
        public IEnumerable<WeatherForecast> GetLength()
        {
            return CreateWeatherForecats();
        }

        // http://localhost:5000/WeatherForecast/long/123456789
        // http://localhost:5000/WeatherForecast/long/9223372036854775807
        [HttpGet]
        [Route("long/{customParam:long}")]
        public IEnumerable<WeatherForecast> GetLong()
        {
            return CreateWeatherForecats();
        }

        // ------------------------------------------------------------------

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return CreateWeatherForecats();
        }

        private IEnumerable<WeatherForecast> CreateWeatherForecats()
        {
            // PrintSomeValues();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        private void PrintSomeValues()
        {
            // Значення для constraint :guid

            Console.WriteLine(Guid.NewGuid());

            // Які можуть бути формати значення для constraint :datetime

            DateTime date = new DateTime(2014, 8, 28, 12, 28, 30);
            DateTimeFormatInfo invDTF = new DateTimeFormatInfo();
            String[] formats = invDTF.GetAllDateTimePatterns();

            Console.WriteLine("{0,-40} {1}\n", "Pattern", "Result String");
            foreach (var fmt in formats)
                Console.WriteLine("{0,-40} {1}", fmt, date.ToString(fmt));

            Console.WriteLine(date);
        }
    }
}
