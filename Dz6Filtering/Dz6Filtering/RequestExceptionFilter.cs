using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Dz6Filtering
{
    public class RequestExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly ILogger<RequestExceptionFilter> _logger;
        private string _errorString = "Цей запит не може бути оброблено";

        public RequestExceptionFilter(ILogger<RequestExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            if (context.Exception != null)
            {
                _logger.LogError(context.Exception, _errorString);
                context.ExceptionHandled = true;

                context.Result = new ContentResult { Content = _errorString };
            }

            _logger.LogInformation("RequestExceptionFilter.OnException");
        }
    }
}
