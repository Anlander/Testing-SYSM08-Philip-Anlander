using CRJTestrunner.BaseSetup;
using TechTalk.SpecFlow;

namespace CRJTestrunner.Tests;

[Binding]
[Scope(Tag = "AddToCart")]
[Trait("Category", "AddToCart")]
public class AddToCart : PlayWrightBase
{
  [Given("I am on the product archive page")]
  public async Task GivenIAmOnTheProductArchivePage()
  {
    await LoginAsync("philip@anlander.se", "Password123!");
  }

  [When(@"I click the ""(.*)"" button for product id ""(.*)""")]
  public async Task WhenIClickButtonForProductId(string buttonText, string productId)
  {
    var addToCartButton = Page.Locator($"form:has(input[name='productId'][value='{productId}']) button");
    await addToCartButton.ClickAsync();
  }

  [Then(@"I should see the product added to the cart")]
  public Task ThenIShouldSeeTheProductInTheCart()
  {
    var expectedUrl = "http://localhost:5211/Cart";
    var actualUrl = Page.Url;
    Assert.Equal(expectedUrl, actualUrl);
    return Task.CompletedTask;
  }
}

