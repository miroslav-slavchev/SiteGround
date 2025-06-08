using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;
using SiteGround.Application.UiElements.Buttons;
using SiteGround.Application.UiElements.Icons;
using Microsoft.Playwright;

namespace SiteGround.Application.PageObjects.Generic.Message
{
    public class Notification(SearchContext searchContext, By? by = null) : PageObject(searchContext, by ?? Locate.By("css=div.sg-box-notification"))
    {
        public NotificationHeading Heading => InnerPageObject<NotificationHeading>(Locate.By("css=h3.sg-box-notification__title"));
        public Button Back => UiElement<Button>(Locate.By("css=button.sg-box-notification__back-button"));
        public SgIcon Icon => UiElement<SgIcon>(Locate.By("css=span.sg-box-notification__icon"));

        public async Task<Notification?> PresentAsync()
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

    public class NotificationHeading(SearchContext searchContext, By? by = null) : PageObject(searchContext, by ?? Locate.By("css=h3.sg-box-notification__title"))
    {
        public UiElement Emphasis => UiElement(Locate.By("css=strong em"));
    }
}
