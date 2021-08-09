using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace DzDependencyInjection.Middlewares
{
    public class AddContentToArticleMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public AddContentToArticleMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task InvokeAsync(
            HttpContext context,
            IAddContentToTheArticleService addContentToTheArticleService
            )
        {
            // - сервіс, який вносить контент в статтю (наприклад з якогось файлу на диску)
            addContentToTheArticleService.AddContent();

            await _requestDelegate.Invoke(context);
        }
    }
}
