using GlideGo_WebAutomation_BDD.Drivers;
using GlideGoWeb.PageObjects;
using NUnit.Framework;
using ProjectUtilityExcel;
using ProjectUtilityReporting;
using Reqnroll;
using System;

namespace GlideGo_WebAutomation_BDD.StepDefinitions
{
    [Binding]
    public class TC_004_PendingRequestsApprovalFunctionalityStepDefinitions:Setup
    {
        private int rowNumber;
        private string username;
        private string password;
        private string userTripId;
        private string[] budgetHolderUsernames;
        private string[] supervisorsUsernames;
        private string[] budgetHoldersPasswords;
        private string[] supervisorsPasswords;
        private string[] budgetHoldersTripIds;
        private string[] supervisorsTripIds;

        private PreLoginPage pre = default!;
        private LoginPage login = default!;
        private Dashboard dash = default!;
        private ReviewApprovePage review = default!;
        private TripApprovalPage approval = default!;

        public TC_004_PendingRequestsApprovalFunctionalityStepDefinitions()
        {

            ExcelReaderUtil.PopulateInCollection(excelpath, "TripApprovalData");

            string row = ExcelReaderUtil.ReadData(1, "ConfigRow") ?? string.Empty;

            string[] rowArray = row.Split('-');
            int arrayLenght = rowArray.Length;

            int[] configRowArray = new int[arrayLenght] ;

            for (int i = 0; i < arrayLenght; i++)
            {
                rowArray[i] = rowArray[i].Trim();
                configRowArray[i] = Convert.ToInt32(rowArray[i]);
            }

            int firstConfigRow = configRowArray[0];
            int lastConfigRow = configRowArray[configRowArray.Length - 1];

            rowNumber = firstConfigRow;
            
            username = ExcelReaderUtil.ReadData(rowNumber, "Username") ?? string.Empty;
            password = ExcelReaderUtil.ReadData(rowNumber, "Password") ?? string.Empty;
            userTripId = ExcelReaderUtil.ReadData(rowNumber, "UserTripId") ?? string.Empty;

            budgetHolderUsernames = new string[lastConfigRow];
            budgetHoldersPasswords = new string[lastConfigRow];
            budgetHoldersTripIds = new string[lastConfigRow];

            supervisorsUsernames = new string[lastConfigRow];
            supervisorsPasswords = new string[lastConfigRow];
            supervisorsTripIds = new string[lastConfigRow];

            for(int i=0; i<lastConfigRow; i++)
            {
                budgetHolderUsernames[i] = ExcelReaderUtil.ReadData(i + firstConfigRow, "BudgetHolderUserName") ?? string.Empty;
                budgetHoldersPasswords[i] = ExcelReaderUtil.ReadData(i + firstConfigRow, "BudgetHolderPassword") ?? string.Empty;
                budgetHoldersTripIds[i] = ExcelReaderUtil.ReadData(i + firstConfigRow, "BudgetHolderTripId") ?? string.Empty;
                supervisorsUsernames[i] = ExcelReaderUtil.ReadData(i + firstConfigRow, "SupervisorUsername") ?? string.Empty;
                supervisorsPasswords[i] = ExcelReaderUtil.ReadData(i + firstConfigRow, "SupervisorPassword") ?? string.Empty;
                supervisorsTripIds[i] = ExcelReaderUtil.ReadData(i + firstConfigRow, "SupervisorTripId") ?? string.Empty;


            }


        }

        [Given("open the application")]
        public async Task GivenAPendingRequestExists()
        {
            page = await factory.InitBrowser(browserName);

            pre = new PreLoginPage(page);
            login = new LoginPage(page);
            dash = new Dashboard(page);
            review = new ReviewApprovePage(page);
            approval = new TripApprovalPage(page);

            await page.GotoAsync(url);

            ExtentReporting.LogInfo($"Goto the url:{url}");

        }


        [When("the budget holder accepts the pending request")]
        public async Task WhenTheBudgetHolderAcceptsThePendingRequest()
        {
            for(int i=0; i<budgetHolderUsernames.Length; i++)
            {
                await pre.ClickOnContinueAsGuest();
                await login.EnterUsername(budgetHolderUsernames[i]);
                await login.EnterPassword(budgetHoldersPasswords[i]);
                await login.ClickOnLoginButton();

                await dash.ClickOnReviewAndApproval();
                await review.ClickOnTripDetails(budgetHoldersTripIds[i]);
                await approval.ClickOnApproveButton();

            }

        }

        [Then("the system updates the request status to Accepted for budget holder")]
        public async Task ThenTheSystemUpdatesTheRequestStatusToAcceptedForBudgetHolder()
        {
            bool actualResult = await approval.IsSuccessfullyApproved();
            Assert.That(actualResult, Is.True);
        }

        [Then("the supervisor accepts the pending request")]
        public async Task ThenTheSupervisorAcceptsThePendingRequest()
        {
            throw new PendingStepException();
        }

        [Then("the system updates the request status to Accepted for supervisor")]
        public async Task ThenTheSystemUpdatesTheRequestStatusToAcceptedForSupervisor()
        {
            throw new PendingStepException();
        }

        [When("the budget holder rejects the pending request")]
        public async Task WhenTheBudgetHolderRejectsThePendingRequest()
        {
            throw new PendingStepException();
        }

        [Then("the system updates the request status to Rejected")]
        public async Task ThenTheSystemUpdatesTheRequestStatusToRejected()
        {
            throw new PendingStepException();
        }

        [When("the budget holder accept the pending request")]
        public async Task WhenTheBudgetHolderAcceptThePendingRequest()
        {
            throw new PendingStepException();
        }

        [When("the supervisor rejects the pending request")]
        public async Task WhenTheSupervisorRejectsThePendingRequest()
        {
            throw new PendingStepException();
        }

        [When("the supervisor accepts the pending request")]
        public async Task WhenTheSupervisorAcceptsThePendingRequest()
        {
            throw new PendingStepException();
        }



    }
}
