using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;
using SiteGround.Application.PageObjects.Email.Accounts.ManageEmailAccounts;

namespace SiteGround.Application.PageObjects.Email.Accounts
{
    public class AccountsPage(SearchContext searchContext, By? by = null) : PageObject(searchContext, by ?? Locate.By("css=main"))
    {
        public SelectDomainModule SelectDomain => InnerPageObject<SelectDomainModule>(Locate.By("css=div.domain-select"));
        public CreateNewEmailAccountModule CreateNewEmailAccount => InnerPageObject<CreateNewEmailAccountModule>(Locate.By("css=section"));
        public ManageEmailAccountsModule ManageEmailAccounts => InnerPageObject<ManageEmailAccountsModule>(Locate.By("css=div:nth-child(2) > div > div > div:nth-child(3)"));
    }
}
