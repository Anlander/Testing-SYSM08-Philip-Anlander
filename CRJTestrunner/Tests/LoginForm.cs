using CRJTestrunner.BaseSetup;
using TechTalk.SpecFlow;

namespace CRJTestrunner.Tests;

[Binding]
[Scope(Tag = "LoginForm")]
public class LoginFormSteps : PlayWrightBase
{
  [Given("I am on the simple login page")]
  public async Task GivenIAmOnTheSimpleFormPage()
  {
    await Page.GotoAsync($"{BaseUrl}/Account/Login");
  }

  [When(@"I enter ""(.*)"" as the username")]
  public async Task WhenIEnterAsTheName(string name)
  {
    await Page.FillAsync("input[name='Email']", name);
  }

  [When(@"I enter ""(.*)"" as the password")]
  public async Task WhenIEnterAsThePassword(string password)
  {
    await Page.FillAsync("input[name='Password']", password);
  }

  [Then("I submit the form")]
  public async Task WhenISubmitTheForm()
  {
    await Page.ClickAsync("#login");
  }
}
