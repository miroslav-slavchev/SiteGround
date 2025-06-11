using Microsoft.Playwright;
using SiteGround.Tests.Infrastructure.Configuration;

namespace SiteGround.Tests
{
    public class BaseTest
    {
        public AppSettings AppSettings { get; } = TestConfiguration.LoadAppSettings();
        public App App { get; private set; }

        [OneTimeSetUp]
        public async Task Setup()
        {
            BrowserPageSession browserSession = await StartBrowserSessionAsync();
            App = new(browserSession);

            var page = browserSession.Page;
            var baseUrl = AppSettings.App.Url;
            var token = AppSettings.User.Token;
            string fullUrl = $"{baseUrl}?demoToken={token}";

            await page.GotoAsync(fullUrl);
        }

        private async Task<BrowserPageSession> StartBrowserSessionAsync()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            });
            var browserContext = await browser.NewContextAsync();
            var page = await browserContext.NewPageAsync();

            BrowserPageSession browserPageSession = new(playwright, page);
            return browserPageSession;
        }

        [OneTimeTearDown]
        public async Task CleanUp()
        {
            await App.BrowserPageSession.Browser.CloseAsync();
        }
    }
}
