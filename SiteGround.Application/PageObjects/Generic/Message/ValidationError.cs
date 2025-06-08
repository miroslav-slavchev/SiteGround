using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;
using SiteGround.Application.UiElements.Icons;
using Microsoft.Playwright;

namespace SiteGround.Application.PageObjects.Generic.Message
{
    public class ValidationError(SearchContext searchContext, By by) : PageObject(searchContext, by)
    {
        public SgIcon Icon => UiElement<SgIcon>(Locate.By("css=span:nth-child(1)"));
        public UiElement Message => UiElement(Locate.By("css=span:nth-child(2)"));

        public async Task<ValidationError?> PresentAsync()
        {
            try
            {
                await Locator.WaitForAsync(new()
                {
                    State = WaitForSelectorState.Attached,
                    Timeout = 3000
                });
                return this;
            }
            catch
            {
                return null;
            }
        }
    }
}
