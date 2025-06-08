using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;
using SiteGround.Application.UiElements.Inputs;
using SiteGround.Application.PageObjects.Generic.Message;

namespace SiteGround.Application.PageObjects.Generic.Input
{
    public class TextInputField(SearchContext searchContext, By by) : PageObject(searchContext, by)
    {
        public TextInput Input => UiElement<TextInput>();
        public UiElement AddOn => UiElement(Locate.By("css=span.sg-input-text-truncate"));
        public ValidationError ValidationError => InnerPageObject<ValidationError>(Locate.By("css=div.sg-validation--error"));
    }
}
