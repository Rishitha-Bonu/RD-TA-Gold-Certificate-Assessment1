Feature: Login Validation

  Scenario: API Login Validation
    Given I have a valid username and password
    When I make a POST request to the login API endpoint
    Then I should receive a successful response
    And the response body should contain user details