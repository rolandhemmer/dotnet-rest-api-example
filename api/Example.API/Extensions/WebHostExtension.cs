using Example.API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Example.API.Extensions
{
    public static class WebHostExtension
    {
        #region METHODS

        public static void SeedDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = new ExampleContext(scope.ServiceProvider.GetRequiredService<DbContextOptions>());

            context.Database.Migrate();
        }

        #endregion METHODS
    }
}
