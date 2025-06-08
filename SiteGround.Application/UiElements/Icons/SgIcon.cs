using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;

namespace SiteGround.Application.UiElements.Icons
{
    public class SgIcon(SearchContext searchContext, By by) : UiElement(searchContext, by)
    {
        public async Task<string?> DataIconAsync() => await GetAttributeAsync("data-icon");
        public async Task<bool> IsSuccessAsync() => await GetAttributeAsync("data-icon") == "success";
        public async Task<bool> IsErrorAttentionAsync() => await GetAttributeAsync("data-icon") == "error-attention";
    }
}
