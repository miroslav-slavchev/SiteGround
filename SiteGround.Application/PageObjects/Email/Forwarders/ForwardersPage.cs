using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;
using SiteGround.Application.PageObjects.Email.Accounts;

namespace SiteGround.Application.PageObjects.Email.Forwarders
{
    public class ForwardersPage(SearchContext searchContext, By by) : PageObject(searchContext, by)
    {
        public SelectDomainModule SelectDomain => InnerPageObject<SelectDomainModule>(Locate.By("css=div.domain-select"));

        public CreateNewRuleModule CreateNewRule => InnerPageObject<CreateNewRuleModule>(Locate.By("css=section"));
    }
}
