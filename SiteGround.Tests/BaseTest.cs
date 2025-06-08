using Microsoft.Playwright;
using PlayWright.Library;
using SiteGround.Application;
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
            BrowserSession browserSession = await StartBrowserSessionAsync();
            App = new(browserSession);

            var page = browserSession.Page;
            var baseUrl = AppSettings.App.Url;
            var token = AppSettings.User.Token;
            string fullUrl = $"{baseUrl}?demoToken={token}";

            await page.GotoAsync(fullUrl);
        }

        private async Task<BrowserSession> StartBrowserSessionAsync()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            });
            var browserContext = await browser.NewContextAsync();
            var page = await browserContext.NewPageAsync();

            BrowserSession browserSession = new(playwright, page);
            return browserSession;
        }

        [OneTimeTearDown]
        public async Task CleanUp()
        {
            await App.BrowserSession.Browser.CloseAsync();
        }
    }
}
