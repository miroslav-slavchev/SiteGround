using PlayWright.Library.Components.Context;

namespace SiteGround.Application.UiElements.Buttons.SwitchButtons
{
    public class ShowHideButton(SearchContext searchContext, By? by = null) : SwitchIconButton(searchContext, by ?? Locate.By("css=span.sg-icon[data-icon=eye],span.sg-icon[data-icon=eye-cross]"))
    {
        protected override string PositiveIcon => "eye";
        protected override string NegativeIcon => "eye-cross";

        public async Task<bool> IsShownAsync() => await PositiveStateAsync();
        public async Task<bool> HiddenAsync() => await NegativeStateAsync();

        public async Task IsShowAsync() => await PositiveSwitchAsync();
        public async Task IsHideAsync() => await NegativeSwitchAsync();
    }
}
