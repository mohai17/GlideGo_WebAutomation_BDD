using GlideGo_WebAutomation_BDD.Drivers;
using GlideGo_WebAutomation_BDD.Pages;
using GlideGoWeb.PageObjects;
using NUnit.Framework;
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
        private int arrayLength;
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
        private SOFManagementPage sofManage = default!;
        private SOFFormPage sofForm = default!;

        public TC_005_SourceOfFundsManagementStepDefinitions()
        {
            ExcelReaderUtil.PopulateInCollection(excelpath, "SOFData");

            string row = ExcelReaderUtil.ReadData(1, "ConfigRow") ?? string.Empty;

            string[] rowArray = row.Split('-');
            int arrayLen = rowArray.Length;

            int[] configRowArray = new int[arrayLen];

            for (int i = 0; i < arrayLen; i++)
            {
                rowArray[i] = rowArray[i].Trim();
                configRowArray[i] = Convert.ToInt32(rowArray[i]);
            }

            int firstConfigRow = configRowArray[0];
            int lastConfigRow = configRowArray[configRowArray.Length - 1];
            arrayLength = lastConfigRow;
         
            narrative = new string[arrayLength];
            accountCode = new string[arrayLength];
            costCenter = new string[arrayLength];
            project = new string[arrayLength];
            sof = new string[arrayLength];
            drc = new string[arrayLength];
            activity = new string[arrayLength];
            budgetHolders = new string[arrayLength];
            percentage = new string[arrayLength];

            for (int i=0; i<arrayLength; i++)
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

        [Given("Open the application and goto the url for sof management")]
        public async Task GivenOpenTheApplicationAndGotoTheUrlForSofManagement()
        {
            page = await factory.InitBrowser(browserName);
            login = new LoginPage(page);
            pre = new PreLoginPage(page);
            dash = new Dashboard(page);
            sofManage = new SOFManagementPage(page);
            sofForm = new SOFFormPage(page);

            await page.GotoAsync(url);

            ExtentReporting.LogInfo($"Goto the url:{url}");
        }


        [Given("the user navigates to the Source of Funds creation form")]
        public async Task GivenTheUserNavigatesToTheSourceOfFundsCreationForm()
        {
            await pre.ClickOnContinueAsGuest();
            await login.EnterUsername(username);
            await login.EnterPassword(password);
            await login.ClickOnLoginButton();

            await dash.ClickOnSOFManagement();
            await sofManage.ClickOnAddSOFButton();
     

        }

        [When("the user fills out all required fields")]
        public async Task WhenTheUserFillsOutAllRequiredFields()
        {

            for (int i = 0; i < arrayLength; i++)
            {
                await sofForm.EnterNarrative(narrative[i]);
                await sofForm.EnterAccountCode(accountCode[i]);
                await sofForm.SelectCostCenter(costCenter[i]);
                await sofForm.SelectProject(project[i]);
                await sofForm.SelectSOF(sof[i]);
                await sofForm.SelectDRC(drc[i]);
                await sofForm.SelectActivity(activity[i]);
                await sofForm.SelectBudgetHolder(budgetHolders[i]);
                await sofForm.EnterPercentage(percentage[i]);
                await sofForm.ClickOnAddSOFButton();

            }

            await page.EvaluateAsync("window.scrollBy(0, 500)");

            await sofForm.EnterSOFName(sofName);


        }

        [When("clicks the Save button")]
        public async Task WhenClicksTheSaveButton()
        {
            
            await sofForm.ClickOnSaveButton();
        }

        [Then("displays a confirmation message")]
        public async Task ThenDisplaysAConfirmationMessage()
        {
            bool actualResult = await sofManage.IsSOFSuccessfullyCreated();
            Assert.That(actualResult, Is.True);
        }

        [Given("the user has an existing Source of Funds record")]
        public async Task GivenTheUserHasAnExistingSourceOfFundsRecord()
        {
            throw new PendingStepException();
        }

        [When("the user selects the record")]
        public async Task WhenTheUserSelectsTheRecord()
        {
            throw new PendingStepException();
        }

        [When("clicks the Delete button")]
        public async Task WhenClicksTheDeleteButton()
        {
            throw new PendingStepException();
        }

        [Then("displays a deletion confirmation message")]
        public async Task ThenDisplaysADeletionConfirmationMessage()
        {
            throw new PendingStepException();
        }

        [When("updates the required fields")]
        public async Task WhenUpdatesTheRequiredFields()
        {
            throw new PendingStepException();
        }

        [Then("displays an update confirmation message")]
        public async Task ThenDisplaysAnUpdateConfirmationMessage()
        {
            throw new PendingStepException();
        }

        [Given("the user is on the Source of Funds creation form")]
        public async Task GivenTheUserIsOnTheSourceOfFundsCreationForm()
        {
            throw new PendingStepException();
        }

        [When("the user enters data into the form")]
        public async Task WhenTheUserEntersDataIntoTheForm()
        {
            throw new PendingStepException();
        }

        [When("clicks the Cancel button")]
        public async Task WhenClicksTheCancelButton()
        {
            throw new PendingStepException();
        }

        [Then("the system does not save any entered data")]
        public async Task ThenTheSystemDoesNotSaveAnyEnteredData()
        {
            throw new PendingStepException();
        }

    }
}
