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

    [When(@"I enter ""(.*)"" as the name")]
    public async Task WhenIEnterAsTheName(string productTest)
    {
        await Page.FillAsync("#Product_Name", productTest);
    }

    [When(@"I enter ""(.*)"" as the description")]
    public async Task WhenIEnterAsTheDescription(string description)
    {
        await Page.FillAsync("#Product_Description", description);
    }

    [When(@"I enter ""(.*)"" as the price")]
    public async Task WhenIEnterAsThePrice(string price)
    {
        await Page.FillAsync("#Product_Price", price);
    }

    [When(@"I select list of categories")]
    public void WhenISelectListOfCategories()
    {
        Page.ClickAsync("#SelectedCategory");
    }

    [When(@"I select ""(.*)"" as the category value")]
    public async Task WhenISelectAsTheCategory(string value)
    {
        await Page.SelectOptionAsync("#SelectedCategory", value);
    }

    [When(@"I enter ""(.*)"" as the image URL")]
    public async Task WhenISelectAsTheImageURL(string image)
    {
        await Page.FillAsync("#Product_Image", image);
    }

    [Then(@"I submit the form")]
    public async Task ThenISubmitTheForm()
    {
        await Page.ClickAsync("#createProduct");
    }

    [When(@"I filter categories by ""(.*)"" and filter name by ""(.*)""")]
    public async Task WhenIFilterCategoriesByAndFilterNameBy(string category, string name)
    {
        await Page.FillAsync("#searchQuery", name);
        await Page.ClickAsync("#selectedCategoryId");
        await Page.SelectOptionAsync("#selectedCategoryId", category);
    }

    [Then(@"I should see the product ""(.*)"" in the list")]
    public async Task ThenIShouldSeeTheFilteredProducts(string product)
    {
        var filteredProduct = await Page.Locator("#cardProduct h4").InnerTextAsync();
        Assert.Contains("Camera", filteredProduct);
    }


    [When(@"I click on the edit button for the product")]
    public async Task WhenIClickOnTheEditButtonForTheProduct()
    {
        var cameraCard = Page.Locator(".card:has(#cardProduct h4:has-text('Camera'))");
        await cameraCard.Locator("#productEdit").ClickAsync();
    }

    [When(@"I enter ""(.*)"" as the new name")]
    public async Task WhenIEnterAsTheNewName(string newName)
    {
        var input = Page.Locator("#Product_Name");
        await input.ClearAsync();
        await Page.FillAsync("#Product_Name", newName);
    }
    [Then(@"I save the edit form")]
    public async Task ThenISaveTheEditForm()
    {
        await Page.ClickAsync("#saveEdit");
    }

    [When(@"I click on the delete button for the product")]
    public async Task WhenIClickOnTheDeleteButtonForTheProduct()
    {
        var cameraCard = Page.Locator(".card:has(#cardProduct h4:has-text('Camera 2'))");
        await cameraCard.Locator("#productDelete").ClickAsync();
    }

    [Then(@"I confirm the delete action")]
    public async Task ThenIConfirmTheDeleteAction()
    {
        await Page.Locator("input[value='Delete']").First.ClickAsync();
    }
}
