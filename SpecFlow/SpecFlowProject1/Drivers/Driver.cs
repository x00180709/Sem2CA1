using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Drivers
{
    public class Driver : IDisposable
    {
        private readonly Task<IPage> _page;
        private IBrowser? _browser;
        public Driver()
        {
            _page = InitializePlaywright();
        }

        public IPage Page => _page.Result;

        void IDisposable.Dispose() => _browser?.CloseAsync();

        private async Task<IPage> InitializePlaywright()
        {
            using var playwright = await Playwright.CreateAsync();

            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            return await _browser.NewPageAsync();
        }
    }
}
