
@AdminCrud

Feature: Admin CRUD
   As a admin
   I want to manage the products as admin

Scenario: Admin create remove and edit product
    Given I am logged in as an admin
    When I navigate to the admin product page
    Then I should see the admin product page
    When I navigate to create a new product
    And I enter "ProductTest" as the name
    And I enter "An short description" as the description
    And I enter "2000" as the price
    And I enter "Password123!" as the password
    # Then I should see the product "Test Product" in the product list
    # When I edit the product "Test Product" to have the name "Updated Product" and price "150"
    # Then I should see the product "Updated Product" in the product list
    # When I remove the product "Updated Product"
    # Then I should not see the product "Updated Product" in the product list
