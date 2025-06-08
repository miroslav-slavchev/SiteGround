using PlayWright.Library.Components.Context;
using SiteGround.Application.PageObjects.Generic;

namespace SiteGround.Application.PageObjects.Email.Accounts.ManageEmailAccounts
{
    public class ManageEmailAccountsModule(SearchContext searchContext, By by) : Module(searchContext, by)
    {
        public EmailAccountsTable Table => InnerPageObject<EmailAccountsTable>(Locate.By("table.sg-table"));
    }
}
