using Microsoft.Extensions.Configuration;

namespace SiteGround.Tests.Infrastructure.Configuration
{
    public static class TestConfiguration
    {
        public static AppSettings LoadAppSettings()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var settings = new AppSettings();
            config.Bind(settings);
            return settings;
        }
    }
}
