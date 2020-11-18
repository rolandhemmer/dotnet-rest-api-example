using Example.API.Configuration.Models;

namespace Example.API.Configuration
{
    public sealed class AppSettings
    {
        public DatabaseConfigurationModel Database { get; set; }

        public ServiceConfigurationModel Service { get; set; }
    }
}
