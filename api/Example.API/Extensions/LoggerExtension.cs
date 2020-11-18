using System;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace Example.API.Extensions
{
    public static class LoggerExtension
    {
        public static LoggerConfiguration AddLoggerConfiguration(
            this LoggerConfiguration loggerConfiguration,
            string serviceNamespace = "<unknown>",
            string level = "Information")
        {
            var levelSwitch = new LoggingLevelSwitch
            {
                MinimumLevel = !string.IsNullOrEmpty(level) && Enum.TryParse<LogEventLevel>(level, true, out var value) ? value : LogEventLevel.Information
            };

            var overrideLevel = levelSwitch.MinimumLevel == LogEventLevel.Information ? LogEventLevel.Warning : levelSwitch.MinimumLevel;

            var logger = loggerConfiguration
                .MinimumLevel.ControlledBy(levelSwitch)
                .MinimumLevel.Override("Microsoft", overrideLevel)
                .MinimumLevel.Override("System", overrideLevel)
                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication.JwtBearer", LogEventLevel.Fatal)
                .Enrich.FromLogContext()
                .WriteTo.Console(
                    outputTemplate: $"[{{Timestamp:yyyy-MM-dd HH:mm:ss.fff}} {serviceNamespace} ({{SourceContext}}) {{Level:u3}}] {{Message:j}}{{NewLine}}{{Exception}}",
                    theme: AnsiConsoleTheme.Code);

            return logger;
        }
    }
}
