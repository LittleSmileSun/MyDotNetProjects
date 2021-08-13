using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Dz4LoggerProvider.ColorLogging
{
    public static class ColorLoggerExtensions
    {
        public static ILoggingBuilder AddColorLogger(
            this ILoggingBuilder builder, 
            Action<ColorLoggingOptions> configure
            )
        {
            builder.Services.AddSingleton<ILoggerProvider, ColorLoggerProvider>();
            builder.Services.Configure(configure);

            return builder;
        }
    }
}
