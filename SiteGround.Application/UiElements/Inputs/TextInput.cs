using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;

namespace SiteGround.Application.UiElements.Inputs
{
    public class TextInput(SearchContext searchContext, By? by = null) : UiElement(searchContext, by ?? Locate.By("css=input[data-e2e=text-input-name]"))
    {
    }
}
