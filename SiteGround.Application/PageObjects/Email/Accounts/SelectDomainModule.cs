using PlayWright.Library.Components.Context;
using SiteGround.Application.PageObjects.Generic;
using SiteGround.Application.UiElements.Select;

namespace SiteGround.Application.PageObjects.Email.Accounts
{
    public class SelectDomainModule(SearchContext searchContext, By by) : Module(searchContext, by)
    {
        public SgDtopDown DropDown => InnerPageObject<SgDtopDown>(Locate.By("css=div.sg-dropdown-wrapper"));
    }
}
