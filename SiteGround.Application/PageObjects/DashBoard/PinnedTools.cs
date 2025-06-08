using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;

namespace SiteGround.Application.PageObjects.DashBoard
{
    public class PinnedTools(SearchContext searchContext) : PageObject(searchContext, Locate.By("css=> div > div > div > div > div:nth-child(2)"))
    {
        public UiElementList<UiElement> Items => UiElements<UiElement>(Locate.By("css=div.dashboard-tile--clickable"));

        public UiElement this[string name] => Items.FirstWithText(name);
        public UiElement EmailAccounts => this["Email Accounts"];
    }
}
