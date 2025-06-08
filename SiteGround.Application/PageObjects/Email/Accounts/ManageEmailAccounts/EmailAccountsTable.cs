using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;

namespace SiteGround.Application.PageObjects.Email.Accounts.ManageEmailAccounts
{
    public class EmailAccountsTable(SearchContext searchContext, By by) : PageObject(searchContext, by)
    {
        public UiElementList Columns => UiElements(Locate.By("css=thead th"));
        public PageObjectList<EmailAccountTableRow> Rows => InnerPageObjects<EmailAccountTableRow>(Locate.By("css=tr.sg-table__row"));
    }
}
