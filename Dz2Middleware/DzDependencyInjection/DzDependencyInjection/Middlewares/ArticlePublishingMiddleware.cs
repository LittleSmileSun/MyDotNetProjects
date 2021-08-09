using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace DzDependencyInjection.Middlewares
{
    public class ArticlePublishingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public ArticlePublishingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task InvokeAsync(
            HttpContext context,
            IArticlePublishingService articlePublishingService
            )
        {
            // - сервіс, який опубліковує статтю
            articlePublishingService.Publish();

            await context.Response.WriteAsync("Article published");
            //await _requestDelegate.Invoke(context);
        }
    }
}
