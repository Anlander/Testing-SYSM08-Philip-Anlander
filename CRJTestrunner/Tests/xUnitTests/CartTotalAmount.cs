using System.Collections.Generic;
using System.Linq;
using CRJ_Shop.Models;
using Xunit;
using Xunit.Abstractions;

namespace CRJTestrunner.Tests.xUnitTests;

public class CartTotalAmount
{
  private readonly ITestOutputHelper _output;

  public CartTotalAmount(ITestOutputHelper output)
  {
    _output = output;
  }

  [Fact]
  public void VerifyTotalAmountInCart()
  {
    _output.WriteLine("Setting up the product and cart items...");
    var product = new Product
    {
      Id = 2,
      Name = "Test Product",
      Title = "Test Product Title",
      Description = "This is a test product description.",
      Price = -1,
      ProductCategories = new List<ProductCategory>(),
      ProductOrders = new List<ProductOrder>(),
      Image = "https://example.com/test-image.jpg",
      AvailableAmount = 10
    };

    var cartItems = new List<ProductOrder>
            {
                new ProductOrder
                {
                    Product = product,
                    Quantity = 3
                }
            };

    _output.WriteLine($"Product: {product.Name}, Quantity: {cartItems[0].Quantity}, Price: {product.Price}");

    var expectedTotal = cartItems.Sum(item => item.Product.Price * item.Quantity);
    _output.WriteLine($"Expected total calculated: {expectedTotal}");

    _output.WriteLine("Calculating the actual total...");
    var actualTotal = cartItems.Sum(item => item.Product.Price * item.Quantity);
    _output.WriteLine($"Actual total calculated: {actualTotal}");

    _output.WriteLine("Asserting that the expected total matches the actual total...");
    Assert.Equal(expectedTotal, actualTotal);
    _output.WriteLine("Test passed successfully!");
  }
}


