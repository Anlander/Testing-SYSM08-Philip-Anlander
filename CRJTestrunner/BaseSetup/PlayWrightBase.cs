using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace CRJTestrunner.Steps
{
    public class PlayWrightBase
    {
        protected IPlaywright Playwright { get; private set; } = null!;
        protected IBrowser Browser { get; private set; } = null!;
        protected IBrowserContext Context { get; private set; } = null!;
        protected IPage Page { get; private set; } = null!;

        [BeforeScenario]
        public async Task Setup()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true,
                SlowMo = 500
            });
            Context = await Browser.NewContextAsync();
            Page = await Context.NewPageAsync();
        }

        [AfterScenario]
        public async Task Teardown()
        {
            if (Browser is not null)
                await Browser.CloseAsync();

            Playwright?.Dispose();
        }
    }
}
