using Microsoft.Extensions.Configuration;
using Serilog.Events;
using System;

namespace Serilog.DynamicMinimumLogLevel
{
    public static class ConfigurationExtensions
    {
        public static LogEventLevel GetMinimumLoggingLevel(this IConfiguration config)
        {
            var logLevel = config["LogLevel"];

            Enum.TryParse<LogEventLevel>(logLevel, out var serilogLogLevel);

            if (logLevel != "Verbose" && serilogLogLevel == LogEventLevel.Verbose)
                return LogEventLevel.Information;

            return serilogLogLevel;
        }
    }
}
