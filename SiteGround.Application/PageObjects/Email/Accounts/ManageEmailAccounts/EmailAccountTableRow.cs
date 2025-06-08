using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;

namespace SiteGround.Application.PageObjects.Email.Accounts.ManageEmailAccounts
{
    public class EmailAccountTableRow(SearchContext searchContext, By speifiedBy) : PageObject(searchContext, speifiedBy)
    {
        public UiElement AccountName => UiElement(Locate.By("css=td:nth-child(1)"));
        public UiElement CurrentUsageAndQuota => UiElement(Locate.By("css=td:nth-child(2)"));
        public UiElement ExpandActionsMenu => UiElement(Locate.By("css=td:nth-child(3)"));
    }
}
