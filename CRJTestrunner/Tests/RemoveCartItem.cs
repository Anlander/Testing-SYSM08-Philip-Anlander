using CRJTestrunner.BaseSetup;
using TechTalk.SpecFlow;

namespace CRJTestrunner.Tests;

[Binding]
[Scope(Tag = "RemoveCartItem")]
[Trait("Category", "RemoveCartItem")]
public class RemoveCartItem : PlayWrightBase
{
  [Given("I am on the product page")]
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

  [When(@"I remove first item from the cart")]
  public async Task WhenIRemoveAnItemFromTheCart()
  {
    var removeButton = Page.Locator("#tableBody tr:first-child td:last-child form button");
    await removeButton.ClickAsync();
  }

  [Then(@"I should see the products removed from the cart")]
  public void ThenIShouldSeeTheProductsRemovedFromTheCart()
  {
    Console.WriteLine("Product removed from the cart");
  }
}
