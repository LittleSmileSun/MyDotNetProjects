using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Dz4LoggerProvider.ColorLogging
{
    [ProviderAlias("ColorLogger")]
    public class ColorLogger : ILogger
    {
        private DateTime _date;
        protected readonly ColorLoggerProvider _provider;
        private static object _lock = new object();

        public ColorLogger([NotNull] ColorLoggerProvider provider)
        {
            _provider = provider;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception,
            string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            lock (_lock) {
                var logLine = formatter(state, exception) + exception + " {" + eventId + "} " + 
                    Environment.NewLine;

                 string stateStr = state.ToString();

                 ConsoleColor defaultTxtColor = ConsoleColor.Gray;

                 var stateColors = new Dictionary<string, ConsoleColor> {
                     { "Trace", ConsoleColor.Cyan },
                     { "Debug", ConsoleColor.DarkGray },
                     { "Information", ConsoleColor.DarkGreen },
                     { "Warning", ConsoleColor.Yellow },
                     { "Error", ConsoleColor.Red },
                     { "Critical", ConsoleColor.Magenta },

                 };

                 Console.ForegroundColor = stateColors[stateStr];

                 Console.WriteLine($"[!] {stateStr}");
                 Console.WriteLine($"{logLine}");

                 Console.ForegroundColor = defaultTxtColor;
            }
        }
    }
}
