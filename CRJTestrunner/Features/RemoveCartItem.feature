
@RemoveCartItem

Feature: Remove cart item
  As a customer
  I want to remove a product from my cart

Scenario: Remove all product from the cart
    Given I am on the product page
    When I click the "Add to cart" button for product id "2"
    And I remove all item from the cart
    Then I should see the products removed from the cart
