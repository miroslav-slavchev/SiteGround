using PlayWright.Library.Components.Context;

namespace PlayWright.Library.Components
{
    public class UiElementList<TUiElement>(SearchContext searchContext, By by)
        : UiContextList<TUiElement>(searchContext, by) where TUiElement : UiElement
    { }

    public class UiElementList(SearchContext searchContext, By by)
        : UiElementList<UiElement>(searchContext, by)
    { }
}
