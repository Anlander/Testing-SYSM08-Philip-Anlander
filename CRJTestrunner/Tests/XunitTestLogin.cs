
using Microsoft.Playwright;
using Xunit;

public class LoginTests : IAsyncLifetime
{
    private IPlaywright _playwright = null!;
    private IBrowser _browser = null!;
    private IPage _page = null!;

    public async Task InitializeAsync()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new()
        {
            Headless = false,
            SlowMo = 500
        });
        _page = await _browser.NewPageAsync();
    }

    [Fact]
    public async Task Should_Login_Successfully()
    {
        await _page.GotoAsync("http://localhost:5211/Account/Login");

        await _page.FillAsync("input[name='Email']", "philip@anlander.se");
        await _page.FillAsync("input[name='Password']", "Password123!");

        await _page.ClickAsync("#login");

    }

    public async Task DisposeAsync()
    {
        if (_browser != null)
            await _browser.CloseAsync();

        _playwright?.Dispose();
    }
}
