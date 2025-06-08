using Microsoft.Playwright;
using PlayWright.Library.Components.Context;
using PlayWright.Library;
using SiteGround.Application.PageObjects.Navigation;
using SiteGround.Application.PageObjects.Email;
using SiteGround.Application.PageObjects.DashBoard;

namespace SiteGround.Application
{
    public class App(BrowserSession browserSession)
    {
        private ILocator Body => BrowserSession.Page.Locator("css=body");
        private SearchContext BodyContext => new(browserSession: BrowserSession, parent: null, root: Body);

        public BrowserSession BrowserSession { get; } = browserSession;

        public SideNavigation SideNavigation => new(BodyContext);

        public EmailPage EmailPage => new(BodyContext, Locate.By("css=main"));

        public DashBoardPage DashBoard => new(BodyContext, Locate.By("css=main"));
    }
}
