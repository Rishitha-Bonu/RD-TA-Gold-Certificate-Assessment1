Feature: API Tests

Scenario: Login Validation API Test
    Given I have valid user credentials
    When I make a POST request to the login endpoint
    Then I should receive a valid response
    And the response should contain the correct user details
