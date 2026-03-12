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
    public class LogoutAndSessionInvalidationBehaviorStepDefinitions:Setup
    {
       
        private int rowNumber;
        private string username;
        private string password;

        public LogoutAndSessionInvalidationBehaviorStepDefinitions()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            ExcelReaderUtil.PopulateInCollection(excelpath, "LogoutData");
            rowNumber = Convert.ToInt32(ExcelReaderUtil.ReadData(1, "ConfigRow") ?? string.Empty);
            username = ExcelReaderUtil.ReadData(rowNumber, "Username") ?? string.Empty;
            password = ExcelReaderUtil.ReadData(rowNumber, "Password") ?? string.Empty;
        }

        [Given("the application is available")]
        public async Task GivenTheApplicationIsAvailable()
        {
            page = await factory.InitBrowser(browserName);
            try
            {
                await page.GotoAsync(url);
            }
            catch (Exception)
            {

                await page.ReloadAsync();
            }

            ExtentReporting.LogInfo($"Goto the url:{url}");
        }

        [Given("the user is logged into the web app")]
        public async Task GivenTheUserIsLoggedIntoTheWebApp()
        {
            PreLoginPage pre = new PreLoginPage(page);
            await pre.ClickOnContinueAsGuest();

            LoginPage login = new LoginPage(page);
            await login.EnterUsername(username);
            await login.EnterPassword(password);
            await login.ClickOnLoginButton();

        }

        [When("the user clicks the Logout button in the header")]
        public async Task WhenTheUserClicksTheLogoutButtonInTheHeader()
        {
            Dashboard dash = new Dashboard(page);
          
            await dash.ClickOnProfileIcon();
  
            await dash.ClickOnLogoutButton();
        }

        [Then("the user should be redirected to the pre-login page")]
        public async Task ThenTheUserShouldBeRedirectedToThePreLoginPage()
        {
            PreLoginPage pre = new PreLoginPage(page);
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
            PreLoginPage pre = new PreLoginPage(page);
            bool actualResult = await pre.IsItPreLoginPage();

            Assert.That(actualResult, Is.True);
        }

    }
}
