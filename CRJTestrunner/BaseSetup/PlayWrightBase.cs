using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace CRJTestrunner.BaseSetup
{
  public class PlayWrightBase
  {
    protected IPlaywright Playwright { get; private set; } = null!;
    protected IBrowser Browser { get; private set; } = null!;
    protected IBrowserContext Context { get; private set; } = null!;
    protected IPage Page { get; private set; } = null!;
    protected string BaseUrl { get; } = "http://localhost:5211";


    [BeforeScenario]
    public async Task Setup()
    {
      Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
      Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
      {
        Headless = false,
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

    protected async Task LoginAsync(string username, string password)
    {
      await Page.GotoAsync($"{BaseUrl}/Account/Login");
      await Page.FillAsync("input[name='Email']", username);
      await Page.FillAsync("input[name='Password']", password);
      await Page.ClickAsync("#login");
    }
  }
}
