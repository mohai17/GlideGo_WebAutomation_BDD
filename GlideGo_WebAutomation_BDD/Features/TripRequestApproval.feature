Feature: TC_004_Pending Requests Approval Functionality
  As a budget holder or supervisor
  I want to accept or reject pending requests
  So that the system updates the request status accordingly

  @ignore
  Scenario: TS_001_Budget Holder and Supervisor accept a pending request when flow is budget holder to supervisor
    Given Open the Application and Get Test Data for "TS_001"
    When the budget holder accepts the pending request
    Then the system updates the request status to Accepted for budget holder
    When the supervisor accepts the pending request
    Then the system updates the request status to Accepted for supervisor
  
  @ignore
  Scenario: TS_002_Budget holder rejects a pending request when flow is budget holder to supervisor
    Given Open the Application and Get Test Data for "TS_002"
    When the budget holder rejects the pending request
    Then the system updates the request status to Rejected

  @ignore
  Scenario: TS_003_Supervisor rejects a pending request when flow is budget holder to supervisor
    Given Open the Application and Get Test Data for "TS_003"
    When the budget holder accepts the pending request
    Then the system updates the request status to Accepted for budget holder
    When the supervisor rejects the pending request
    Then the system updates the request status to Rejected

  
  Scenario: TS_004_Supervisor and Budget Holder accept a pending request when flow is supervisor to budget holder
    Given Open the Application and Get Test Data for "TS_004"
    When the supervisor accepts the pending request
    Then the system updates the request status to Accepted for supervisor
    When the budget holder accepts the pending request
    Then the system updates the request status to Accepted for budget holder


  Scenario: TS_005_Supervisor rejects a pending request when flow is supervisor to budget holder
    Given Open the Application and Get Test Data for "TS_005"
    When the supervisor rejects the pending request
    Then the system updates the request status to Rejected

  Scenario: TS_006_Budget holder rejects a pending request when flow is supervisor to budget holder
    Given Open the Application and Get Test Data for "TS_006"
    When the supervisor accepts the pending request
    Then the system updates the request status to Accepted for supervisor
    When the budget holder rejects the pending request
    Then the system updates the request status to Rejected
