namespace CRJTestrunner.Steps;

using TechTalk.SpecFlow;
using CRJTestrunner.BaseSetup;

[Binding]
[Scope(Tag = "createAccount")]
public class CreateAccountSteps : PlayWrightBase
{

  [Given("I am on the create account page")]
  public async Task GivenIAmOnTheCreateAccountPage()
  {
    await Page.GotoAsync("http://localhost:5211/Account/Register");
  }

  [When(@"I enter ""(.*)"" as the email")]
  public async Task WhenIEnterAsTheEmail(string name)
  {
    await Page.FillAsync("input[name='Input.Email']", name);
  }

  [When(@"I enter ""(.*)"" as the first name")]
  public async Task WhenIEnterAsFirstName(string name)
  {
    await Page.FillAsync("input[name='Input.FirstName']", name);
  }

  [When(@"I enter ""(.*)"" as the last name")]
  public async Task WhenIEnterAsLastName(string name)
  {
    await Page.FillAsync("input[name='Input.LastName']", name);
  }

  [When(@"I enter ""(.*)"" as the city")]
  public async Task WhenIEnterAsTheCity(string stockholm)
  {
    await Page.FillAsync("input[name='Input.Address']", stockholm);
  }

  [When(@"I enter ""(.*)"" as the password")]
  public async Task WhenIEnterAsTheFirstPassword(string password)
  {
    await Page.FillAsync("input[name='Input.Password']", password);
  }

  [When("I submit the form with errors")]
  public async Task WhenISubmitTheFormWithError()
  {
    await Page.ClickAsync("#registerSubmit");
  }

  [When("I should see text validation error")]
  public async Task ThenIShouldSeeAConfirmationMessage()
  {
    await Page.WaitForSelectorAsync("#confirm-password");

    var errorMessage = await Page.InnerTextAsync("#confirm-password");

    Assert.Equal("The Confirm password field is required.", errorMessage);
  }


  [When(@"I enter ""(.*)"" as the password again")]
  public async Task WhenIEnterAsTheFirstPasswordAgain(string password)
  {
    await Page.FillAsync("input[name='Input.Password']", password);
  }

  [When(@"I enter ""(.*)"" as the password confirmation")]
  public async Task WhenIEnterAsTheFirstPasswordConfirmation(string password)
  {
    await Page.FillAsync("#Input_ConfirmPassword", password);
  }

  [Then("I submit the form")]
  public async Task WhenISubmitTheForm()
  {
    await Page.ClickAsync("#registerSubmit");
  }
}
