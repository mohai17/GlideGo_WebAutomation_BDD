
Feature: Logout and session invalidation behavior
  As an authenticated user
  I want to log out securely
  So that my session is invalidated and cannot be reused across navigation

  Background:
    Given the application is available
    And the user is logged into the web app

  @happy_path
  Scenario: User logs out successfully
    When the user clicks the Logout button in the header
    Then the user should be redirected to the pre-login page


  @security @no-cache
  Scenario: Back navigation after logout does not restore session
    When the user clicks the Logout button in the header
    And the user navigates back using the browser back button
    Then the user remains on the login page

