Feature: Pending Requests Approval Functionality
  As a budget holder or supervisor
  I want to accept or reject pending requests
  So that the system updates the request status accordingly

  Background:
    Given a pending request exists

  Scenario: User accepts a pending request when flow is budget holder to supervisor
    When the budget holder accepts the pending request
    Then the system updates the request status to Accepted for budget holder
    And the supervisor accepts the pending request
    Then the system updates the request status to Accepted for supervisor

  Scenario: Budget holder rejects a pending request when flow is budget holder to supervisor
    When the budget holder rejects the pending request
    Then the system updates the request status to Rejected

  Scenario: Supervisor rejects a pending request when flow is budget holder to supervisor
    When the budget holder accept the pending request
    And the supervisor rejects the pending request
    Then the system updates the request status to Rejected

  Scenario: User accepts a pending request when flow is supervisor to budget holder
    When the supervisor accepts the pending request
    Then the system updates the request status to Accepted for supervisor
    When the budget holder accepts the pending request
    Then the system updates the request status to Accepted for budget holder


  Scenario: Supervisor rejects a pending request when flow is supervisor to budget holder
    When the supervisor rejects the pending request
    Then the system updates the request status to Rejected

  Scenario: Budget holder rejects a pending request when flow is supervisor to budget holder
    When the supervisor accepts the pending request
    And the budget holder rejects the pending request
    Then the system updates the request status to Rejected