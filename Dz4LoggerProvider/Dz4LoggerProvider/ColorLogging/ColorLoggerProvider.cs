using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Dz4LoggerProvider.ColorLogging
{
    [ProviderAlias("ColorLogger")]
    public class ColorLoggerProvider : ILoggerProvider
    {
        public readonly ColorLoggingOptions Options;

        public ColorLoggerProvider(IOptions<ColorLoggingOptions> options)
        {
            Options = options.Value;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new ColorLogger(this);
        }

        public void Dispose()
        {
            
        }
    }
}
