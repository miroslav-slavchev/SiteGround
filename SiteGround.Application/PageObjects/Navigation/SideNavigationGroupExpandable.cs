using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;

namespace SiteGround.Application.PageObjects.Navigation
{
    public class SideNavigationGroupExpandable(SearchContext searchContext, By? by = null) : PageObject(searchContext, by ?? Locate.By("css=li.sg-navigation-list"))
    {
        public UiElement Title => UiElement<UiElement>(Locate.By("css=span.sg-navigation-list__title"));

        public UiElementList<UiElement> SubPages => UiElements<UiElement>(Locate.By("css=li.sg-navigation-list__item"));

        public async Task<UiElement> ActiveSubPage()
        {
            return await SubPages.FirstOrDefaultAsync(async subPage => (await subPage.GetAttributeAsync("class"))!.Contains("sg-navigation-list__item--active"))
                ?? throw new Exception("No active page");
        }
    }
}
