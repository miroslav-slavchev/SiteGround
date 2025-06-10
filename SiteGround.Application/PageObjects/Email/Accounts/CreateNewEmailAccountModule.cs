using PlayWright.Library.Components.Context;
using SiteGround.Application.PageObjects.Generic;
using SiteGround.Application.PageObjects.Generic.Input;
using SiteGround.Application.PageObjects.Generic.Message;
using SiteGround.Application.UiElements.Buttons;
using SiteGround.Application.UiElements.Icons;

namespace SiteGround.Application.PageObjects.Email.Accounts
{
    public class CreateNewEmailAccountModule(SearchContext searchContext, By by) : Module(searchContext, by)
    {
        public TextInputField AccountName => InnerPageObject<TextInputField>(Locate.By("css=label[data-e2e=text-input-name-label]"));
        public FormPasswordField Password => InnerPageObject<FormPasswordField>(Locate.By("css=label[data-e2e=form-password-password-label]"));
        public Button CreateButton => UiElement<Button>(Locate.By("css=button[data-e2e=create-box-submit]"));
        public LoadSpinner LoadSpinner => UiElement<LoadSpinner>();

        public async Task ClickCreateButtonAsync()
        {
            await CreateButton.ClickAsync();
            await LoadSpinner.WaitToBeHiiden();
        }

        public Notification Notification => InnerPageObject<Notification>(Locate.By("css=div.sg-box-notification"));
    }
}
