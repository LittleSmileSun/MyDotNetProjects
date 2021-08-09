using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace DzDependencyInjection.Middlewares
{
    public class CheckByCriterionsMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public CheckByCriterionsMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task InvokeAsync(
            HttpContext context,
            ICheckArticleByCriterionsService checkArticleByCriterionsService
            )
        {
            // - сервіс, який виконує перевірку статті по якимось критеріям
            checkArticleByCriterionsService.CheckByCriterions();
            
            await _requestDelegate.Invoke(context);
        }
    }
}
