using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Dz6Filtering
{
    public class RequestAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private IConfiguration _configuration;
        private readonly ILogger<RequestExceptionFilter> _logger;

        private IConfigurationService configurationService { get; } 

        public RequestAuthorizationFilter(
            ILogger<RequestExceptionFilter> logger,
            IConfigurationService configurationService)
        {
            _logger = logger;
            this.configurationService = configurationService;
            _configuration = configurationService.Configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var cookies = context.HttpContext.Request.Cookies;
            var headers = context.HttpContext.Request.Headers;

            var cookie1 = cookies["cookie1"];
            var cookie2 = cookies["cookie2"];
            var header = headers["header"];

            var section = _configuration.GetSection(nameof(RequestData));
            var config = section.Get<RequestData>();

            if (!IsAllParams(cookies, headers))
            {
                _logger.LogError("No some param/s to request");
                context.Result = new ContentResult { Content = "No some param/s to request." };
            }

            /* if (!(cookie1 == config.cookie1 && cookie2 == config.cookie2 && header == config.header))
            {
                context.Result = new ContentResult { Content = "Requested data is not equals to config." };
            } */

            bool isCookie1Int = int.TryParse(cookie1, out int n1);
            bool isCookie2Int = int.TryParse(cookie2, out int n2);
            bool isHeaderInt = int.TryParse(header, out int head);

            if((!isCookie1Int) || (!isCookie2Int) || (!isHeaderInt)) 
            {
                _logger.LogError("Requested data is not valid.");
                context.Result = new ContentResult { Content = "Requested data is not valid." };
            }

            if (n1 / n2 != head)
            {
                _logger.LogError("Cookie1 + Cookie2 != Header.");
                context.Result = new ContentResult { Content = "Cookie1 + Cookie2 != Header." };
            }

            _logger.LogInformation("OnAuthorization.Good");

            // Success request, if you need finish it
            // context.Result = new ContentResult { Content = "Authorization method worked good." };
        }

        private bool IsAllParams(IRequestCookieCollection cookies, IHeaderDictionary headers)
        {
            return (
                cookies.ContainsKey("cookie1") 
                && cookies.ContainsKey("cookie2") 
                && headers.ContainsKey("header")
            );
        }
    }
}
