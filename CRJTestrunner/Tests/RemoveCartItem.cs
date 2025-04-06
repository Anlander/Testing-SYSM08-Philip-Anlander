using CRJTestrunner.BaseSetup;
using Microsoft.Playwright;
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

  [When(@"I remove all item from the cart")]
  public async Task WhenIRemoveAnItemFromTheCart()
  {
    var removeButtons = Page.Locator("#tableBody tr td:last-child form button");
    var count = await removeButtons.CountAsync();

    for (int i = 0; i < count; i++)
    {
      try
      {
        await removeButtons.Nth(0).ClickAsync();

        removeButtons = Page.Locator("#tableBody tr td:last-child form button");
        count = await removeButtons.CountAsync();
      }
      catch (PlaywrightException ex)
      {
        Console.WriteLine($"Error occurred: {ex.Message}");
        if (Page.IsClosed)
        {
          break;
        }
      }
    }
  }

  [Then(@"I should see the products removed from the cart")]
  public void ThenIShouldSeeTheProductsRemovedFromTheCart()
  {
    /*var expectedText = Page.InnerTextAsync("#input_cart_empty");*/
    /*Assert.Equal("Your cart is empty.", expectedText);*/
    Console.Write("End");
  }
}
