@AddToCart

Feature: Add to cart
  As a customer
  I want to add a product to my cart

Scenario: Add a product to the cart
    Given I am on the product archive page 
    When I click the "Add to cart" button for product id "2"
    Then I should see the product added to the cart



