using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DzDependencyInjection.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace DzDependencyInjection
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseArticleMiddleware(this IApplicationBuilder appBuilder)
        {
            appBuilder.Map("/publish", b => {
                b.UseMiddleware<SaveArticleInfoMiddleware>();
                b.UseMiddleware<AddContentToArticleMiddleware>();
                b.UseMiddleware<CheckByCriterionsMiddleware>();
                b.UseMiddleware<ArticlePublishingMiddleware>();
            });
            return appBuilder;
        }
    }
}
