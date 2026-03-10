Feature: Guest Login Scenarios
  As a user
  I want to attempt login with different credential combinations
  So that I can verify the system behavior

  @HappyPath
  Scenario: Login with valid username and valid password
    Given I go to the login page URL
    And I click on Continue as Guest button
    When I enter a valid username
    And I enter a valid password
    And I click on the Sign in button
    Then I should see that the login is successful

  @Negative
  Scenario: Login with invalid username and valid password
    Given I go to the login page URL
    And I click on Continue as Guest button
    When I enter an invalid username
    And I enter a valid password
    And I click on the Sign in button
    Then I should see that the invalid login attempts warning displayed

  @Negative
  Scenario: Login with valid username and invalid password
    Given I go to the login page URL
    And I click on Continue as Guest button
    When I enter a valid username
    And I enter an invalid password
    And I click on the Sign in button
    Then I should see that the invalid login attempts warning displayed

  @Negative
  Scenario: Login with empty username and password fields
    Given I go to the login page URL
    And I click on Continue as Guest button
    When I keep the username field empty
    And I keep the password field empty
    And I click on the Sign in button
    Then I should see that required fields warning displayed