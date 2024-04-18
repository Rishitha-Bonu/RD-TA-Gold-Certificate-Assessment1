Feature: UI Tests

Scenario: Login Validation UI Test
    Given I am on the login page
    When I enter valid user credentials
    And click the login button
    Then I should be redirected to the Books dashboard page
    And I should see the correct username displayed
