
@AdminCrud

Feature: Admin CRUD
   As a admin
   I want to manage the products as admin

  Scenario: Full Admin crud scenario 
    Given I am logged in as an admin
    When I navigate to the admin product page
    Then I should see the admin product page

    When I navigate to create a new product
    When I enter "Camera" as the name
    And I enter "An short description" as the description
    And I enter "2000" as the price
    And I select list of categories
    And I select "5" as the category value
    And I enter "https://images-bonnier.imgix.net/files/dif/production/2024/06/18190219/canon_eos_r50-hmgojr0Aeznuu7BWmRN3Hg.jpeg?auto=compress,format&w=1024&fp-x=0.5&fp-y=0.5" as the image URL
    Then I submit the form

    When I filter categories by "4" and filter name by "Camera"  
    Then I should see the product "Camera" in the list

    When I click on the edit button for the product
    And I enter "Camera 2" as the new name
    Then I save the edit form

    When I click on the delete button for the product
    Then I confirm the delete action


