using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DzMiddlewareArticle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlePublishingController : ControllerBase
    {
        private readonly ICounter _counter;

        public ArticlePublishingController(
            ICounter counter
        )
        {
            _counter = counter;
        }

        // Візьмемо до уваги, що стаття буде публікуватися по якомусь запиті (наприклад, натисненні на кнопку)
        // І по ньому буде публікуватися одна стаття
        [HttpGet]
        public IActionResult Publishing()
        {
            _counter.IncrementValue();

            var value = _counter.GetValue();
            Console.WriteLine($"Number of current article in this moment: {value}");

            return Ok($"Number of current article in this moment: {value}");
        }
    }
}
