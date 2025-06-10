using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;

namespace SiteGround.Application.PageObjects.Navigation
{
    public class SideNavigation(SearchContext searchContext) : PageObject(searchContext, Locate.By("css=aside nav"))
    {
        public UiElement DashBoard => UiElement<UiElement>(Locate.By("css=li.navigation-group-dashboard"));
        public PageObjectList<SideNavigationGroupExpandable> Pages => InnerPageObjects<SideNavigationGroupExpandable>();

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

        public async Task AccountsAsync() => await Navigation.NavigateAsync("Email", "Accounts");
        public async Task ForwardersAsync() => await Navigation.NavigateAsync("Email", "Forwarders");
        public async Task AutorespondersAsync() => await Navigation.NavigateAsync("Email", "Autoresponders");
        public async Task FiltersAsync() => await Navigation.NavigateAsync("Email", "Filters");
        public async Task AuthenticationAsync() => await Navigation.NavigateAsync("Email", "Authentication");
        public async Task SpamProtectionAsync() => await Navigation.NavigateAsync("Email", "Spam Protection");
        public async Task EmailMigratorAsync() => await Navigation.NavigateAsync("Email", "Email Migrator");

    }
}
