using PlayWright.Library.Components.Context;
using SiteGround.Application.PageObjects.Generic;
using SiteGround.Application.PageObjects.Generic.Input;
using SiteGround.Application.UiElements.Buttons;

namespace SiteGround.Application.PageObjects.Email.Forwarders
{
    public class CreateNewRuleModule(SearchContext searchContext, By by) : Module(searchContext, by)
    {
        public Button Create => UiElement<Button>(Locate.By("css=button.sg-button--primary"));

        public TextInputField ForwardAllMessagesSentTo => InnerPageObject<TextInputField>(Locate.By("css=label[data-e2e=forward-crate-name-label]"));
    }
}
