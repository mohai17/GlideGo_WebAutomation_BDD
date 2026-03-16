using GlideGo_WebAutomation_BDD.Drivers;
using GlideGoWeb.PageObjects;
using Microsoft.Playwright;
using NUnit.Framework;
using ProjectUtilityExcel;
using ProjectUtilityReporting;
using Reqnroll;
using System;
using System.Security.Policy;

namespace GlideGo_WebAutomation_BDD.StepDefinitions
{
    [Binding]
    public class LogoutAndSessionInvalidationBehaviorStepDefinitions : Setup
    {

        private int rowNumber;
        private string username;
        private string password;
        private LoginPage login = default!;
        private PreLoginPage pre = default!;
        private Dashboard dash = default!;

        public LogoutAndSessionInvalidationBehaviorStepDefinitions()
        {

            ExcelReaderUtil.PopulateInCollection(excelpath, "LogoutData");
            rowNumber = Convert.ToInt32(ExcelReaderUtil.ReadData(1, "ConfigRow") ?? string.Empty);
            username = ExcelReaderUtil.ReadData(rowNumber, "Username") ?? string.Empty;
            password = ExcelReaderUtil.ReadData(rowNumber, "Password") ?? string.Empty;


        }

        [Given("the application is available")]
        public async Task GivenTheApplicationIsAvailable()
        {

            page = await factory.InitBrowser(browserName);
            login = new LoginPage(page);
            pre = new PreLoginPage(page);
            dash = new Dashboard(page);

            await page.GotoAsync(url);

            ExtentReporting.LogInfo($"Goto the url:{url}");
        }

        [Given("the user is logged into the web app")]
        public async Task GivenTheUserIsLoggedIntoTheWebApp()
        {
 
            await pre.ClickOnContinueAsGuest();

            await login.EnterUsername(username);
            await login.EnterPassword(password);
            await login.ClickOnLoginButton();

        }

        [When("the user clicks the Logout button in the header")]
        public async Task WhenTheUserClicksTheLogoutButtonInTheHeader()
        {
            await dash.ClickOnProfileIcon();
            await dash.ClickOnLogoutButton();
        }

        [Then("the user should be redirected to the pre-login page")]
        public async Task ThenTheUserShouldBeRedirectedToThePreLoginPage()
        {

            bool actualResult = await pre.IsItPreLoginPage();
            Assert.That(actualResult, Is.True);
        }

        [When("the user navigates back using the browser back button")]
        public async Task WhenTheUserNavigatesBackUsingTheBrowserBackButton()
        {
            await page.WaitForRequestFinishedAsync();
            await page.GoBackAsync();

        }

        [Then("the user remains on the login page")]
        public async Task ThenTheUserRemainsOnTheLoginPage()
        {
            bool actualResult = await pre.IsItPreLoginPage();
            Assert.That(actualResult, Is.True);
        }

    }
}