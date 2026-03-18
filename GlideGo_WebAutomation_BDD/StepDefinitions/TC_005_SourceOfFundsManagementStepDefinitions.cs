using GlideGo_WebAutomation_BDD.Drivers;
using GlideGoWeb.PageObjects;
using ProjectUtilityExcel;
using ProjectUtilityReporting;
using Reqnroll;
using System;
using System.Diagnostics;

namespace GlideGo_WebAutomation_BDD.StepDefinitions
{
    [Binding]
    public class TC_005_SourceOfFundsManagementStepDefinitions:Setup
    {

        private int rowNumber;
        private string username;
        private string password;
        private string sofName;
        private string[] narrative;
        private string[] accountCode;
        private string[] costCenter;
        private string[] project;
        private string[] sof;
        private string[] drc;
        private string[] activity;
        private string[] budgetHolders;
        private string[] percentage;



        private LoginPage login = default!;
        private PreLoginPage pre = default!;
        private Dashboard dash = default!;

        public TC_005_SourceOfFundsManagementStepDefinitions()
        {
            ExcelReaderUtil.PopulateInCollection(excelpath, "SOFData");

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

            narrative = new string[lastConfigRow];
            accountCode = new string[lastConfigRow];
            costCenter = new string[lastConfigRow];
            project = new string[lastConfigRow];
            sof = new string[lastConfigRow];
            drc = new string[lastConfigRow];
            activity = new string[lastConfigRow];
            budgetHolders = new string[lastConfigRow];
            percentage = new string[lastConfigRow];

            for (int i=0; i<lastConfigRow; i++)
            {

                narrative[i] = ExcelReaderUtil.ReadData(i + firstConfigRow, "Narrative") ?? string.Empty;
                accountCode[i] = ExcelReaderUtil.ReadData(i + firstConfigRow, "AccountCode") ?? string.Empty;
                costCenter[i] = ExcelReaderUtil.ReadData(i + firstConfigRow, "CostCenter") ?? string.Empty;
                project[i] = ExcelReaderUtil.ReadData(i + firstConfigRow, "Project") ?? string.Empty;
                sof[i] = ExcelReaderUtil.ReadData(i + firstConfigRow, "SOF") ?? string.Empty;
                drc[i] = ExcelReaderUtil.ReadData(i + firstConfigRow, "DRC") ?? string.Empty;
                activity[i] = ExcelReaderUtil.ReadData(i + firstConfigRow, "Activity") ?? string.Empty;
                budgetHolders[i] = ExcelReaderUtil.ReadData(i + firstConfigRow, "BudgetHolder") ?? string.Empty;
                percentage[i] = ExcelReaderUtil.ReadData(i + firstConfigRow, "Percentage") ?? string.Empty;


            }


            rowNumber = firstConfigRow;

            username = ExcelReaderUtil.ReadData(rowNumber, "Username") ?? string.Empty;
            password = ExcelReaderUtil.ReadData(rowNumber, "Password") ?? string.Empty;
            sofName = ExcelReaderUtil.ReadData(rowNumber, "SOFName") ?? string.Empty;

        }


        [Given("Open the application and goto the url")]
        public async Task GivenOpenTheApplicationAndGotoTheUrl()
        {
            page = await factory.InitBrowser(browserName);
            login = new LoginPage(page);
            pre = new PreLoginPage(page);
            dash = new Dashboard(page);

            await page.GotoAsync(url);

            ExtentReporting.LogInfo($"Goto the url:{url}");
        }

        [Given("the user navigates to the Source of Funds creation form")]
        public void GivenTheUserNavigatesToTheSourceOfFundsCreationForm()
        {
            throw new PendingStepException();
        }

        [When("the user fills out all required fields")]
        public void WhenTheUserFillsOutAllRequiredFields()
        {
            throw new PendingStepException();
        }

        [When("clicks the Save button")]
        public void WhenClicksTheSaveButton()
        {
            throw new PendingStepException();
        }

        [Then("displays a confirmation message")]
        public void ThenDisplaysAConfirmationMessage()
        {
            throw new PendingStepException();
        }

        [Given("the user has an existing Source of Funds record")]
        public void GivenTheUserHasAnExistingSourceOfFundsRecord()
        {
            throw new PendingStepException();
        }

        [When("the user selects the record")]
        public void WhenTheUserSelectsTheRecord()
        {
            throw new PendingStepException();
        }

        [When("clicks the Delete button")]
        public void WhenClicksTheDeleteButton()
        {
            throw new PendingStepException();
        }

        [Then("displays a deletion confirmation message")]
        public void ThenDisplaysADeletionConfirmationMessage()
        {
            throw new PendingStepException();
        }

        [When("updates the required fields")]
        public void WhenUpdatesTheRequiredFields()
        {
            throw new PendingStepException();
        }

        [Then("displays an update confirmation message")]
        public void ThenDisplaysAnUpdateConfirmationMessage()
        {
            throw new PendingStepException();
        }

        [Given("the user is on the Source of Funds creation form")]
        public void GivenTheUserIsOnTheSourceOfFundsCreationForm()
        {
            throw new PendingStepException();
        }

        [When("the user enters data into the form")]
        public void WhenTheUserEntersDataIntoTheForm()
        {
            throw new PendingStepException();
        }

        [When("clicks the Cancel button")]
        public void WhenClicksTheCancelButton()
        {
            throw new PendingStepException();
        }

        [Then("the system does not save any entered data")]
        public void ThenTheSystemDoesNotSaveAnyEnteredData()
        {
            throw new PendingStepException();
        }

    }
}
