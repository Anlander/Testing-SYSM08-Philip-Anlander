@LoginForm
Feature: Login Form

Scenario: Login form
    Given I am on the simple login page
    When I enter "philip@anlander.se" as the username
    And I enter "Password123!" as the password
    Then I submit the form

    Examples:
      | name                 | password   
      | philip@anlander.se   | 3108457Pa!
