using Microsoft.Extensions.Configuration;

namespace Example.API.Configuration.Provider
{
    public sealed class ConfigurationProvider : IConfigurationProvider
    {
        #region MEMBERS

        private IConfigurationRoot _configurationRoot;

        #endregion MEMBERS

        #region PROPERTIES

        public AppSettings AppSettings { get; } = new AppSettings();

        #endregion PROPERTIES

        #region CONSTRUCTORS

        public ConfigurationProvider()
        {
            if (_configurationRoot == null)
            {
                BuildConfiguration();
            }
        }

        #endregion CONSTRUCTORS

        #region METHODS

        public IConfiguration GetConfiguration()
        {
            return _configurationRoot;
        }

        private void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, false)
                .AddEnvironmentVariables();

            _configurationRoot = builder.Build();
            _configurationRoot.Bind(AppSettings);
        }

        #endregion METHODS
    }
}
