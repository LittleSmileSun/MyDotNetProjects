using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace DzDependencyInjection
{
    public class SaveArticleInfoMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public SaveArticleInfoMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task InvokeAsync(
            HttpContext context, 
            ISaveArticleInfoService saveArticleInfoService
            )
        {
            // - сервіс, який зберігає інформацію про статтю, яку потрібно опублікувати
            saveArticleInfoService.SaveMainArticleInfo("Name 1", "Author 1");

            await _requestDelegate.Invoke(context);
        }
    }
}
