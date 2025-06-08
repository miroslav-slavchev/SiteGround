using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;

namespace SiteGround.Application.PageObjects.Generic
{
    public abstract class Module(SearchContext searchContext, By by) : PageObject(searchContext, by)
    {
        public UiElement Heading => UiElement<UiElement>(Locate.By("css=h2"));
    }
}
