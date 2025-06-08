using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;

namespace SiteGround.Application.UiElements.Buttons.SwitchButtons
{
    public abstract class SwitchIconButton(SearchContext searchContext, By by) : UiElement(searchContext, by)
    {
        public async Task<string?> DataIconAttributeAsync() => await GetAttributeAsync("data-icon");
        protected abstract string PositiveIcon { get; }
        public async Task<bool> PositiveStateAsync() => await DataIconAttributeAsync() == PositiveIcon;

        protected abstract string NegativeIcon { get; }
        public async Task<bool> NegativeStateAsync() => await DataIconAttributeAsync() == NegativeIcon;

        public async Task PositiveSwitchAsync()
        {
            if (await NegativeStateAsync())
            {
                await ClickAsync();
            }
        }

        public async Task NegativeSwitchAsync()
        {
            if (await PositiveStateAsync())
            {
                await ClickAsync();
            }
        }
    }
}
