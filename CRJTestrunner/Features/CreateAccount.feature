
@createAccount

Feature: Create Account

Scenario: create account form
    Given I am on the create account page
    When I enter "example@example.se" as the email

    And I enter "Joe" as the first name
    And I enter "Doe" as the last name
    And I enter "Stockholm" as the city
    And I enter "Password123!" as the password
    And I submit the form with errors
    And I should see text validation error
    And I enter "Password123!" as the password again
    And I enter "Password123!" as the password confirmation
    # And I enter "Password123!" as the password confirmation
    Then I submit the form
    #
    # Examples:
    #   | name                 | password   
    #   | example@example.se   | Password123!
