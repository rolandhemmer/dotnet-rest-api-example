using Example.API.Configuration.Provider;
using Example.API.Contexts;
using Example.API.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Example.API
{
    public sealed class Startup
    {
        #region METHODS

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseMiddleware<HttpExceptionHandlingMiddleware>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfigurationProvider, ConfigurationProvider>();
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfigurationProvider>();

            services.AddDbContext<ExampleContext>(options => options.UseNpgsql(configuration.AppSettings.Database.Connection));
            services.AddControllers();
        }

        #endregion METHODS
    }
}
