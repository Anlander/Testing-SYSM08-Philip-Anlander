using CRJTestrunner.BaseSetup;
using TechTalk.SpecFlow;

namespace CRJTestrunner.Tests;

[Binding]
[Scope(Tag = "AdminCrud")]
[Trait("Category", "AdminCrud")]
public class AdminCrud : PlayWrightBase
{
  [Given(@"I am logged in as an admin")]
  public async Task GivenIAmOnTheLoginPage()
  {
    await LoginAsync("admin@shop.com", "Password123!");
  }

  [When(@"I navigate to the admin product page")]
  public async Task WhenIShouldSeeTheAdminProductPage()
  {
    await Page.ClickAsync("#manage-products");
  }

  [Then(@"I should see the admin product page")]
  public async Task ThenIShouldSeeTheAdminProductPage()
  {
    var title = await Page.TitleAsync();
    Assert.Equal("Products - CRJ_Shop", title);
  }

  [When(@"I navigate to create a new product")]
  public async Task WhenINavigateToCreateANewProduct()
  {
    await Page.ClickAsync("#createProducut");
  }
  /**/
  /*[When(@"I create a new product with name '(.*)' and price '(.*)'")]*/
  /*public async Task WhenICreateANewProduct(string name, string price)*/
  /*{*/
  /*  await Page.ClickAsync("#create-product");*/
  /*  /*await Page.FillAsync("#product-name", name);*/
  /*  /*await Page.FillAsync("#product-price", price);*/
  /*  /*await Page.ClickAsync("#create-product");*/
  /*}*/
}
