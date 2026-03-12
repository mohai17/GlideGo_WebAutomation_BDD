using BDD_Project_Playwright_DotNet.Drivers;
using GlideGo_WebAutomation_BDD.Drivers;
using GlideGoWeb.PageObjects;
using Microsoft.Playwright;
using NUnit.Framework;
using ProjectUtilityExcel;
using ProjectUtilityPaths;
using ProjectUtilityReporting;
using Reqnroll;
using System;

namespace GlideGo_WebAutomation_BDD.StepDefinitions
{

    [Binding]
    public class GuestLoginScenariosStepDefinitions:Setup
    {
        private int rowNumber;
        private string username;
        private string invalidUsername;
        private string password;
        private string invalidPassword;
        private string userType;
  
        public GuestLoginScenariosStepDefinitions()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            
            ExcelReaderUtil.PopulateInCollection(excelpath, "LoginData");
            rowNumber = Convert.ToInt32(ExcelReaderUtil.ReadData(1, "ConfigRow") ?? string.Empty);
            username = ExcelReaderUtil.ReadData(rowNumber, "Username") ?? string.Empty;
            invalidUsername = ExcelReaderUtil.ReadData(rowNumber, "InvalidUsername") ?? string.Empty;
            password = ExcelReaderUtil.ReadData(rowNumber, "Password") ?? string.Empty;
            invalidPassword = ExcelReaderUtil.ReadData(rowNumber, "InvalidPassword") ?? string.Empty;
            userType = ExcelReaderUtil.ReadData(rowNumber, "UserType") ?? string.Empty;


        }

        [Given("I go to the login page URL")]
        public async Task GivenIGoToTheLoginPageURL()
        {

            page = await factory.InitBrowser(browserName);
            try
            {
                await page.GotoAsync(url);
            }
            catch(Exception)
            {
                await page.ReloadAsync();
            }
            ExtentReporting.LogInfo($"Goto the url:{url}");
            

        }

        [Given("I click on Continue as Guest button")]
        public async Task GivenIClickOnContinueAsGuestButton()
        {
            PreLoginPage pre = new PreLoginPage(page);
            await pre.ClickOnContinueAsGuest();
        }

        [When("I enter a valid username")]
        public async Task WhenIEnterAValidUsername()
        {
            LoginPage login = new LoginPage(page);
            await login.EnterUsername(username);
        }

        [When("I enter a valid password")]
        public async Task WhenIEnterAValidPassword()
        {
            LoginPage login = new LoginPage(page);
            await login.EnterPassword(password);
        }

        [When("I click on the Sign in button")]
        public async Task WhenIClickOnTheSignInButton()
        {
            LoginPage login = new LoginPage(page);
            await login.ClickOnLoginButton();
        }

        [Then("I should see that the login is successful")]
        public async Task ThenIShouldSeeThatTheLoginIsSuccessful()
        {
            LoginPage login = new LoginPage(page);
            bool actualResult = await login.IsLoginSucceed(userType);

            Assert.That(actualResult, Is.True);
        }

        [When("I enter an invalid username")]
        public async Task WhenIEnterAnInvalidUsername()
        {
            LoginPage login = new LoginPage(page);
            await login.EnterUsername(invalidUsername);
        }

        [Then("I should see that the invalid login attempts warning displayed")]
        public async Task ThenIShouldSeeThatTheInvalidLoginAttemptsWarningDisplayed()
        {
            LoginPage login = new LoginPage(page);
            bool actualResult = await login.IsInvalidLoginWarningDisplayed();
            Assert.That(actualResult, Is.True);
        }

        [When("I enter an invalid password")]
        public async Task WhenIEnterAnInvalidPassword()
        {
            LoginPage login = new LoginPage(page);
            await login.EnterPassword(invalidPassword);
        }

        [When("I keep the username field empty")]
        public async Task WhenIKeepTheUsernameFieldEmpty()
        {
            LoginPage login = new LoginPage(page);
            await login.EnterUsername("");
            
        }

        [When("I keep the password field empty")]
        public async Task WhenIKeepThePasswordFieldEmpty()
        {
            LoginPage login = new LoginPage(page);
            await login.EnterPassword("");
        }

        [Then("I should see that required fields warning displayed")]
        public async Task ThenIShouldSeeThatRequiredFieldsWarningDisplayed()
        {

            LoginPage login = new LoginPage(page);
            bool result1 = await login.IsEmailWarningDisplayed();
            bool result2 = await login.IsPasswordWaringDisplayed();
            bool actualResult = result1 && result2;

            Assert.That(actualResult, Is.True);

        }

    }
}
