using PlayWright.Library.Components.Context;

namespace PlayWright.Library.Components
{
    public class PageObjectList<TPageObject>(SearchContext searchContext, By by)
        : UiContextList<TPageObject>(searchContext, by) where TPageObject : PageObject
    { }
}
