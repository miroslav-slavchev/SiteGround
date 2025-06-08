using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;

namespace SiteGround.Application.UiElements.Buttons
{
    public class Button(SearchContext searchContext, By? by = null) : UiElement(searchContext, by ?? Locate.By("css=button"))
    {
    }
}
