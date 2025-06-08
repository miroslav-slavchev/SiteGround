namespace SiteGround.Tests.Infrastructure.Configuration
{
    public class AppSettings
    {
        public AppConfig App { get; set; }
        public UserConfig User { get; set; }

        public class AppConfig
        {
            public required string Url { get; set; }
        }

        public class UserConfig
        {
            public required string Token { get; set; }
        }

    }
}
