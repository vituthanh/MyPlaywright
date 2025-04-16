using Microsoft.Playwright;

namespace MyPlaywright.Services
{
    public interface IPlaywrightService : IAsyncDisposable
    {
        Task InitAsync();
        Task<IPage> NewPageAsync();
    }

    public class PlaywrightService : IPlaywrightService
    {
        private IPlaywright _playwright;
        private IBrowser _browser;

        public async Task InitAsync()
        {
            _playwright ??= await Playwright.CreateAsync();
            _browser ??= await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });
        }

        public async Task<IPage> NewPageAsync()
        {
            return await _browser.NewPageAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _browser.CloseAsync();
            _playwright?.Dispose();
        }
    }
}
