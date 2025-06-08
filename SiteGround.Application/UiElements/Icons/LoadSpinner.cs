using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;

namespace SiteGround.Application.UiElements.Icons
{
    public class LoadSpinner(SearchContext searchContext, By? by = null) : UiElement(searchContext, by ?? Locate.By("css=div.sg-loader__spinner"))
    {
    }
}
