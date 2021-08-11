using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Dz3Configuration
{
    public class CatMiddleware
    {
        private readonly RequestDelegate _next;

        public CatMiddleware(RequestDelegate next, IOptions<Cat> options)
        {
            _next = next;
            Cat = options.Value;
        }

        public Cat Cat { get; }

        public async Task InvokeAsync(HttpContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"<p>Name: {Cat?.Name}</p>");
            stringBuilder.Append($"<p>Age: {Cat?.Age}</p>");
            stringBuilder.Append($"<p>Weight: {Cat?.Weight}</p>");
            stringBuilder.Append($"<p>Colour: {Cat?.Colour}</p>");
            stringBuilder.Append($"<p>Owner: {Cat?.Owner?.FirstName} {Cat?.Owner?.LastName}</p>");
            stringBuilder.Append("<h3>Kittens</h3><ul>");
            foreach (string kitten in Cat.Kittens)
                stringBuilder.Append($"<li>{kitten}</li>");
            stringBuilder.Append("</ul>");

            await context.Response.WriteAsync(stringBuilder.ToString());
        }
    }
}
