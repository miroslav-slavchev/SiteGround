using PlayWright.Library.Components.Context;

namespace SiteGround.Application.UiElements.Buttons.SwitchButtons
{
    public class ExpandCollapseIcon(SearchContext searchContext, By? by = null) : SwitchIconButton(searchContext, by ?? Locate.By("css=span.sg-dropdown__icon"))
    {
        protected override string PositiveIcon => "arrow-up";
        protected override string NegativeIcon => "arrow-down";

        public async Task<bool> IsExpandedAsync() => await PositiveStateAsync();
        public async Task<bool> IsCollapsedAsync() => await NegativeStateAsync();

        public async Task ExpandAsync() => await PositiveSwitchAsync();
        public async Task CollapseAsync() => await NegativeSwitchAsync();
    }
}
