using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;

namespace SiteGround.Application.PageObjects.DashBoard
{
    public class DashBoardPage(SearchContext searchContext, By by) : PageObject(searchContext, by)
    {
        public PinnedTools PinnedTools => InnerPageObject<PinnedTools>();
    }
}
