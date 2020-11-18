using System;
using Example.API.Configuration.Provider;
using Example.API.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Example.API
{
    public static class Program
    {
        #region METHODS

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var configurationProvider = new ConfigurationProvider();

            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => webBuilder
                .UseStartup<Startup>()
                .UseConfiguration(configurationProvider.GetConfiguration())
                .UseSerilog());
        }

        public static void Main(string[] args)
        {
            var configurationProvider = new ConfigurationProvider();
            var system = configurationProvider.AppSettings.System;

            Log.Logger = new LoggerConfiguration()
                .AddLoggerConfiguration(system.Name, system.LogLevel)
                .CreateLogger();

            try
            {
                Log.Information("Initializing 'Example API' service");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception exception)
            {
                Log.Error($"Service unexpectedly terminated: '{exception.Message}'");
                Log.Debug($"Exception details => {exception}");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        #endregion METHODS
    }
}
