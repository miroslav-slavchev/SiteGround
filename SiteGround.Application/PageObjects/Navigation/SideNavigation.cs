using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;

namespace SiteGround.Application.PageObjects.Navigation
{
    public class SideNavigation(SearchContext searchContext) : PageObject(searchContext, Locate.By("css=aside nav"))
    {
        public UiElement DashBoard => UiElement<UiElement>(Locate.By("css=li.navigation-group-dashboard"));
        public PageObjectList<SideNavigationGroupExpandable> Pages => InnerPageObjects<SideNavigationGroupExpandable>();

        public async Task NavigateAsync(string pageName)
        {
            var page = await Pages.FirstOrDefaultAsync(async page => await page.Title.TextContentAsync() == pageName)
                ?? throw new ArgumentException($"Page '{pageName}' not found in the side navigation.");

            await page.Title.ClickAsync();
        }

        public async Task NavigateAsync(string pageName, string subPageName)
        {
            var page = await Pages.FirstOrDefaultAsync(async page => await page.Title.TextContentAsync() == pageName)
                ?? throw new ArgumentException($"Page '{pageName}' not found in the side navigation.");

            await page.Title.ClickAsync();

            var subPage = await page.SubPages.FirstOrDefaultAsync(async subPage => await subPage.TextContentAsync() == subPageName)
                ?? throw new ArgumentException($"SubPage '{subPageName}' not found in the side navigation under page '{pageName}'.");

            await subPage.ClickAsync();
        }

        public EmailNavigationList Email => new(this);
    }

    public class EmailNavigationList(SideNavigation navigation)
    {
        public SideNavigation Navigation { get; } = navigation;

        public async Task ClickEmailPageAsync(string subPage) => await Navigation.NavigateAsync("Email");
        public async Task ClickEmailSubPageAsync(string subPage) => await Navigation.NavigateAsync("Email", subPage);
        public async Task ClickAccountsAsync() => await ClickEmailSubPageAsync("Accounts");
        public async Task ClickForwardersAsync() => await ClickEmailSubPageAsync("Forwarders");
        public async Task ClickAutorespondersAsync() => await ClickEmailSubPageAsync("Autoresponders");
        public async Task ClickFiltersAsync() => await ClickEmailSubPageAsync("Filters");
        public async Task ClickAuthenticationAsync() => await ClickEmailSubPageAsync("Authentication");
        public async Task ClickSpamProtectionAsync() => await ClickEmailSubPageAsync("Spam Protection");
        public async Task ClickEmailMigratorAsync() => await ClickEmailSubPageAsync("Email Migrator");

    }
}
