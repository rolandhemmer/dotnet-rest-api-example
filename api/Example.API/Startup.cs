using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.API
{
    public sealed class Startup
    {
        #region PROPERTIES

        public IConfiguration Configuration { get; }

        #endregion PROPERTIES

        #region CONSTRUCTORS

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        #endregion METHODS
    }
}
