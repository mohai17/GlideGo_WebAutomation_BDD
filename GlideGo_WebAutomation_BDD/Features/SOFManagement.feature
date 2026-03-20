Feature: TC_005_Source of Funds Management
  As a system user
  I want to manage Source of Funds (SOF)
  So that I can add, edit, delete, or cancel SOF records effectively

  Background: 
    Given Open the application and goto the url for sof management

  Scenario: TS_001_Successfully add a new Source of Funds
    Given the user navigates to the Source of Funds creation form
    When the user fills out all required fields
    And clicks the Save button
    Then displays a confirmation message

  Scenario: TS_002_Delete an existing Source of Funds
    Given the user has an existing Source of Funds record
    When the user selects the record
    And clicks the Delete button
    Then displays a deletion confirmation message

  Scenario: TS_003_Edit an existing Source of Funds
    Given the user has an existing Source of Funds record
    When the user selects the record
    And updates the required fields
    And clicks the Save button
    Then displays an update confirmation message

  Scenario: TS_004_Cancel Source of Funds creation
    Given the user is on the Source of Funds creation form
    When the user enters data into the form
    And clicks the Cancel button
    Then the system does not save any entered data
    