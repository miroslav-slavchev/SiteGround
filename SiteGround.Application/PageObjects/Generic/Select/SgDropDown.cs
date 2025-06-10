using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;
using SiteGround.Application.UiElements.Buttons.SwitchButtons;

namespace SiteGround.Application.PageObjects.Generic.Select
{
    public class SgDropDown(SearchContext searchContext, By? by = null) : PageObject(searchContext, by ?? Locate.By("css=div.sg-dropdown-wrapper"))
    {
        public ExpandCollapseIcon ExpandCollapse => UiElement<ExpandCollapseIcon>();
        public UiElement Current => UiElement(Locate.By("css=input"));
        private UiElementList Options => UiElements(Locate.By("css=div.sg-dropdown__option"));

        public async Task<UiElementList> OptionsAsync()
        {
            await ExpandCollapse.ExpandAsync();
            var options = Options;
            return options;
        }
        public async Task<List<string>> OptionsTextContentAsync()
        {
            var optionsElements = await OptionsAsync();
            var options = await optionsElements.SelectAsync(option => option.TextContentAsync());
            return options;
        }

        public async Task<string> CurrentSelectedOptionAsync()
        {
            var value = await Current.GetAttributeAsync("placeholder");
            return value!;
        }

        public async Task SelectOptionAsync(string value)
        {
            await ExpandCollapse.ExpandAsync();
            await Options.FirstWithText(value).ClickAsync();
            await Current.WaitForAttributeValueAsync(attributeName: "placeholder", expectedValue: value, timeout: 2000);
        }
    }
}
