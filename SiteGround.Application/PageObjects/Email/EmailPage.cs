using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;
using SiteGround.Application.PageObjects.Email.Accounts;
using SiteGround.Application.PageObjects.Email.Forwarders;

namespace SiteGround.Application.PageObjects.Email
{
    public class EmailPage(SearchContext searchContext, By speifiedBy) : PageObject(searchContext, speifiedBy)
    {
        public AccountsPage Accounts => new(SearchContext, By);

        public ForwardersPage Forwarders => new(SearchContext, By);
    }
}
