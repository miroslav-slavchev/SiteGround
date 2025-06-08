using Microsoft.Playwright;

namespace PlayWright.Library.Components.Context
{
    public class UiContextList<TUiComponent>(SearchContext searchContext, By by) : UiContext(searchContext, by), IAsyncEnumerable<TUiComponent> where TUiComponent : UiComponent
    {
        private List<TUiComponent> All => ToListAsync().Result; // For debug purposes

        public async IAsyncEnumerator<TUiComponent> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            var waitOptions = new PageWaitForSelectorOptions
            {
                State = WaitForSelectorState.Visible,
                Strict = false,
                Timeout = 4000
            };
           
            await Page.WaitForSelectorAsync(By.Selector, waitOptions);

            int count = await Locator.CountAsync();
            for (int i = 0; i < count; i++)
            {
                By nthBy = new(By.Selector, By.Options, By.WaitOptions, By.SearchIn, i);
                var obj = Construct<TUiComponent>(nthBy, SearchContext);
                yield return obj;
            }
        }

        public async Task<List<TUiComponent>> ToListAsync()
        {
            var list = new List<TUiComponent>();
            await foreach (var element in this)
            {
                list.Add(element);
            }
            return list;
        }

        public async Task<TUiComponent> FirstAsync() => (await ToListAsync()).First();
        public async Task<TUiComponent?> FirstOrDefaultAsync() => (await ToListAsync()).FirstOrDefault();
        public async Task<TUiComponent?> FirstOrDefaultAsync(Func<TUiComponent, bool> predicate) => (await ToListAsync()).FirstOrDefault(predicate);
        public async Task<TUiComponent?> FirstOrDefaultAsync(Func<TUiComponent, Task<bool>> predicate)
        {
            TUiComponent? firstOrDefault = null;
            await foreach (var item in this)
            {
                if (await predicate(item))
                    firstOrDefault = item;
            }

            return firstOrDefault;
        }

        public async Task<List<TResult>> SelectAsync<TResult>(Func<TUiComponent, Task<TResult>> asyncSelector)
        {
            ArgumentNullException.ThrowIfNull(asyncSelector);
            var results = new List<TResult>();

            await foreach (var item in this)
            {
                results.Add(await asyncSelector(item));
            }

            return results;
        }

        public TUiComponent FirstWithText(string text)
        {
            var options = By.Options;
            options ??= new();
            options.HasText = text;
            By by = new By(By.Selector, options, By.WaitOptions, By.SearchIn);
            var pageObject = Construct<TUiComponent>(by, SearchContext);
            return pageObject;
        }

        public async Task<TUiComponent> LastAsync() => (await ToListAsync()).Last();
        public async Task<TUiComponent> NthAsync(int index) => (await ToListAsync()).ElementAt(index);
        public async Task<int> CountAsync() => await Locator.CountAsync();
    }
}
