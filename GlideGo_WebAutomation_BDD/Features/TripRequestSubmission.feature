Feature: TC_003_Trip Request Submission
  As a user
  I want to submit trip requests with different options
  So that I can plan and manage travel effectively

  Background: 
    Given Open the application and goto the url
    And the user is logged into the web app as user

  Scenario: TS_001_Create a trip request with only starting and destination points
    When I have entered a starting point
    And I have entered a destination point
    And I have clicked on the Send button
    And I have provided other essential information
    And I submit the trip request
    Then the trip request should be created successfully

  Scenario: TS_002_Add intermediate route points in trip request
    When I have entered a starting point
    And I have entered a destination point
    And I add one or more intermediate route points
    And I have clicked on the Send button
    And I have provided other essential information
    And I submit the trip request
    Then the trip request should be created successfully
