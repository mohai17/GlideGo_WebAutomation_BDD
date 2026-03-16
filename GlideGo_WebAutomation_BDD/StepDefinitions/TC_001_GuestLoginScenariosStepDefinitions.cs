
using GlideGo_WebAutomation_BDD.Drivers;
using GlideGoWeb.PageObjects;
using NUnit.Framework;
using ProjectUtilityExcel;
using ProjectUtilityReporting;


namespace GlideGo_WebAutomation_BDD.StepDefinitions
{

    [Binding]
    public class TC_001_GuestLoginScenariosStepDefinitions : Setup
    {
        private int rowNumber;
        private string username;
        private string invalidUsername;
        private string password;
        private string invalidPassword;
        private LoginPage login = default!;
        private PreLoginPage pre = default!;
 

        public TC_001_GuestLoginScenariosStepDefinitions()
        {          

            ExcelReaderUtil.PopulateInCollection(excelpath, "LoginData");
            rowNumber = Convert.ToInt32(ExcelReaderUtil.ReadData(1, "ConfigRow") ?? string.Empty);
            username = ExcelReaderUtil.ReadData(rowNumber, "Username") ?? string.Empty;
            invalidUsername = ExcelReaderUtil.ReadData(rowNumber, "InvalidUsername") ?? string.Empty;
            password = ExcelReaderUtil.ReadData(rowNumber, "Password") ?? string.Empty;
            invalidPassword = ExcelReaderUtil.ReadData(rowNumber, "InvalidPassword") ?? string.Empty;
    

        }

        [Given("I go to the login page URL")]
        public async Task GivenIGoToTheLoginPageURL()
        {
            page = await factory.InitBrowser(browserName);
            login = new LoginPage(page);
            pre = new PreLoginPage(page);


            await page.GotoAsync(url);

            ExtentReporting.LogInfo($"Goto the url:{url}");


        }

        [Given("I click on Continue as Guest button")]
        public async Task GivenIClickOnContinueAsGuestButton()
        {
            await pre.ClickOnContinueAsGuest();
        }

        [When("I enter a valid username")]
        public async Task WhenIEnterAValidUsername()
        {
            await login.EnterUsername(username);
        }

        [When("I enter a valid password")]
        public async Task WhenIEnterAValidPassword()
        {
            await login.EnterPassword(password);
        }

        [When("I click on the Sign in button")]
        public async Task WhenIClickOnTheSignInButton()
        {
            await login.ClickOnLoginButton();
        }

        [Then("I should see that the login is successful")]
        public async Task ThenIShouldSeeThatTheLoginIsSuccessful()
        {
            bool actualResult = await login.IsLoginSucceed();

            Assert.That(actualResult, Is.True);

        }

        [When("I enter an invalid username")]
        public async Task WhenIEnterAnInvalidUsername()
        {
            await login.EnterUsername(invalidUsername);
        }

        [Then("I should see that the invalid login attempts warning displayed")]
        public async Task ThenIShouldSeeThatTheInvalidLoginAttemptsWarningDisplayed()
        {
            bool actualResult = await login.IsInvalidLoginWarningDisplayed();
            Assert.That(actualResult, Is.True);

        }

        [When("I enter an invalid password")]
        public async Task WhenIEnterAnInvalidPassword()
        {
            await login.EnterPassword(invalidPassword);
        }

        [When("I keep the username field empty")]
        public async Task WhenIKeepTheUsernameFieldEmpty()
        {
            await login.EnterUsername("");

        }

        [When("I keep the password field empty")]
        public async Task WhenIKeepThePasswordFieldEmpty()
        {
            await login.EnterPassword("");
        }

        [Then("I should see that required fields warning displayed")]
        public async Task ThenIShouldSeeThatRequiredFieldsWarningDisplayed()
        {

            bool result1 = await login.IsEmailWarningDisplayed();
            bool result2 = await login.IsPasswordWarningDisplayed();
            bool actualResult = result1 && result2;

            Assert.That(actualResult, Is.True);

        }

    }
}