using AventStack.ExtentReports.Gherkin.Model;
using GlideGo_WebAutomation_BDD.Drivers;
using GlideGoWeb.PageObjects;
using Microsoft.Playwright;
using NUnit.Framework;
using ProjectUtilityExcel;
using ProjectUtilityReporting;
using ProjectUtilityScreenShot;
using Reqnroll;
using System;

namespace GlideGo_WebAutomation_BDD.StepDefinitions
{
    [Binding]
    public class TC_004_PendingRequestsApprovalFunctionalityStepDefinitions:Setup
    {
        private int rowNumber;
        private string[] budgetHolderUsernames = default!;
        private string[] budgetHoldersPasswords = default!;
        private string supervisorsUsername = default!;
        private string supervisorsPassword = default!;
        private string tripId = default!;
        private string[] BudgetholderReason = default!;
        private string SupervisorReason = default!;

        private bool actualResult = true;

        private PreLoginPage pre = default!;
        private LoginPage login = default!;
        private Dashboard dash = default!;
        private ReviewApprovePage review = default!;
        private TripApprovalPage approval = default!;

        private string TestScenarioId = default!;


        private void CallForData(string DataSheet)
        {
            Console.WriteLine(DataSheet);
            ExcelReaderUtil.PopulateInCollection(excelpath, DataSheet);

            string row = ExcelReaderUtil.ReadData(1, "ConfigRow") ?? string.Empty;

            string[] rowArray = row.Split('-');
            int arrayLenght = rowArray.Length;

            int[] configRowArray = new int[arrayLenght];

            for (int i = 0; i < arrayLenght; i++)
            {
                rowArray[i] = rowArray[i].Trim();
                configRowArray[i] = Convert.ToInt32(rowArray[i]);
            }

            int firstConfigRow = configRowArray[0];
            int lastConfigRow = configRowArray[configRowArray.Length - 1];

            rowNumber = firstConfigRow;

            budgetHolderUsernames = new string[lastConfigRow];
            budgetHoldersPasswords = new string[lastConfigRow];
            BudgetholderReason = new string[lastConfigRow];


            for (int i = 0; i < lastConfigRow; i++)
            {
                budgetHolderUsernames[i] = ExcelReaderUtil.ReadData(i + firstConfigRow, "BudgetHolderUsername") ?? string.Empty;
                budgetHoldersPasswords[i] = ExcelReaderUtil.ReadData(i + firstConfigRow, "BudgetHolderPassword") ?? string.Empty;
                BudgetholderReason[i] = ExcelReaderUtil.ReadData(i + firstConfigRow, "BudgetHolderReason") ?? string.Empty;
            }

            tripId = ExcelReaderUtil.ReadData(rowNumber, "TripId") ?? string.Empty;

            supervisorsUsername = ExcelReaderUtil.ReadData(rowNumber, "SupervisorUsername") ?? string.Empty;
            supervisorsPassword = ExcelReaderUtil.ReadData(rowNumber, "SupervisorPassword") ?? string.Empty;
            SupervisorReason = ExcelReaderUtil.ReadData(rowNumber, "SupervisorReason") ?? string.Empty;
        }

        [Given("Open the Application and Get Test Data for {string}")]
        public async Task GivenOpenTheApplicationAndGetTestDataForTS_(string ScenarioId)
        {
            CallForData($"TripApprovalData_{ScenarioId}");

            TestScenarioId = ScenarioId;

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
            actualResult = true;

            for(int i=0; i<budgetHolderUsernames.Length; i++)
            {
                await pre.ClickOnContinueAsGuest();
                await login.EnterUsername(budgetHolderUsernames[i]);
                await login.EnterPassword(budgetHoldersPasswords[i]);
                await login.ClickOnLoginButton();

                await dash.ClickOnReviewAndApproval();
                await review.ClickOnTripDetails(tripId);
                await approval.ClickOnApproveButton();

                bool Result1 = await approval.IsSuccessfullyApproved();
                ExtentReporting.LogScreenshot("Approval", await ScreenshotHelper.TakeScreenshotAsync(page, "Element"));

                await approval.ClickOnTripApprovalList();

                bool Result2 = await approval.IsSuccessfullyDataSaved();
                ExtentReporting.LogScreenshot("Data Saved", await ScreenshotHelper.TakeScreenshotAsync(page, "Element"));

                actualResult = actualResult && Result1 && Result2;

       
                await dash.ClickOnProfileIcon();
                await dash.ClickOnLogoutButton();
                await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
                await pre.IsItPreLoginPage();


            }


        }

        [Then("the system updates the request status to Accepted for budget holder")]
        public async Task ThenTheSystemUpdatesTheRequestStatusToAcceptedForBudgetHolder()
        {
            Assert.That(actualResult, Is.True);
        }

        [When("the supervisor accepts the pending request")]
        public async Task WhenTheSupervisorAcceptsThePendingRequest()
        {
         
                actualResult = true;

                await pre.ClickOnContinueAsGuest();
                await login.EnterUsername(supervisorsUsername);
                await login.EnterPassword(supervisorsPassword);
                await login.ClickOnLoginButton();

                await dash.ClickOnReviewAndApproval();
                await review.ClickOnTripDetails(tripId);
                await approval.ClickOnApproveButton();

                bool Result1 = await approval.IsSuccessfullyApproved();
                ExtentReporting.LogScreenshot("Approval", await ScreenshotHelper.TakeScreenshotAsync(page, "Element"));

                await approval.ClickOnTripApprovalList();

                bool Result2 = await approval.IsSuccessfullyDataSaved();
                ExtentReporting.LogScreenshot("Data Saved", await ScreenshotHelper.TakeScreenshotAsync(page, "Element"));

                actualResult = actualResult && Result1 && Result2;

                await dash.ClickOnProfileIcon();
                await dash.ClickOnLogoutButton();
                await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

        }

        [Then("the system updates the request status to Accepted for supervisor")]
        public async Task ThenTheSystemUpdatesTheRequestStatusToAcceptedForSupervisor()
        {
            Assert.That(actualResult, Is.True);
        }

        [When("the budget holder rejects the pending request")]
        public async Task WhenTheBudgetHolderRejectsThePendingRequest()
        {
            actualResult = false;

            for (int i = 0; i < budgetHolderUsernames.Length; i++)
            {
                await pre.ClickOnContinueAsGuest();
                await login.EnterUsername(budgetHolderUsernames[i]);
                await login.EnterPassword(budgetHoldersPasswords[i]);
                await login.ClickOnLoginButton();

                await dash.ClickOnReviewAndApproval();
                await review.ClickOnTripDetails(tripId);

                if (!string.IsNullOrWhiteSpace(BudgetholderReason[i]))
                {
                    await approval.ClickOnRejectButton();
                    await approval.EnterRejectionReason(BudgetholderReason[i]);
                    await approval.ClickOnPopUpRejectButton();

                    bool Result = await approval.IsSuccessfullyRejected();
                    ExtentReporting.LogScreenshot("Rejected", await ScreenshotHelper.TakeScreenshotAsync(page, "Element"));
                    actualResult = (!actualResult) && Result;

                    break;
                }
                else
                {

                    await approval.ClickOnApproveButton();

                    bool Result1 = await approval.IsSuccessfullyApproved();
                    ExtentReporting.LogScreenshot("Approval", await ScreenshotHelper.TakeScreenshotAsync(page, "Element"));

                    await approval.ClickOnTripApprovalList();

                    bool Result2 = await approval.IsSuccessfullyDataSaved();
                    ExtentReporting.LogScreenshot("Data Saved", await ScreenshotHelper.TakeScreenshotAsync(page, "Element"));

                    await dash.ClickOnProfileIcon();
                    await dash.ClickOnLogoutButton();
                    await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

                    await pre.IsItPreLoginPage();
                }


            }
        }

        [When("the supervisor rejects the pending request")]
        public async Task WhenTheSupervisorRejectsThePendingRequest()
        {
            actualResult = true;

            await pre.ClickOnContinueAsGuest();
            await login.EnterUsername(supervisorsUsername);
            await login.EnterPassword(supervisorsPassword);
            await login.ClickOnLoginButton();

            await dash.ClickOnReviewAndApproval();
            await review.ClickOnTripDetails(tripId);
            await approval.ClickOnRejectButton();
            await approval.EnterRejectionReason(SupervisorReason);
            await approval.ClickOnPopUpRejectButton();

            bool Result = await approval.IsSuccessfullyRejected();
            ExtentReporting.LogScreenshot("Rejected", await ScreenshotHelper.TakeScreenshotAsync(page, "Element"));

            actualResult = actualResult && Result;

        }

        [Then("the system updates the request status to Rejected")]
        public async Task ThenTheSystemUpdatesTheRequestStatusToRejected()
        {
            Assert.That(actualResult, Is.True);
        }



    }
}
