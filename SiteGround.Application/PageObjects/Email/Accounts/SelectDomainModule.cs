using PlayWright.Library.Components.Context;
using SiteGround.Application.PageObjects.Generic;
using SiteGround.Application.PageObjects.Generic.Select;

namespace SiteGround.Application.PageObjects.Email.Accounts
{
    public class SelectDomainModule(SearchContext searchContext, By by) : Module(searchContext, by)
    {
        public SgDropDown DropDown => InnerPageObject<SgDropDown>(Locate.By("css=div.sg-dropdown-wrapper"));
    }
}
