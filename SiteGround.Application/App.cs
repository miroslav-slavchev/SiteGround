using Microsoft.Playwright;
using PlayWright.Library.Components.Context;
using PlayWright.Library;
using SiteGround.Application.PageObjects.Navigation;
using SiteGround.Application.PageObjects.Email;
using SiteGround.Application.PageObjects.DashBoard;

namespace SiteGround.Application
{
    public class App(BrowserPageSession browserSession)
    {
        private ILocator Body => BrowserPageSession.Page.Locator("css=body");
        private SearchContext BodyContext => new(browserSession: BrowserPageSession, parent: null, root: Body);

        public BrowserPageSession BrowserPageSession { get; } = browserSession;

        public SideNavigation SideNavigation => new(BodyContext);

        public EmailPage EmailPage => new(BodyContext, Locate.By("css=main"));

        public DashBoardPage DashBoard => new(BodyContext, Locate.By("css=main"));
    }
}
