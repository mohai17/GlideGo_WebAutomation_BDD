using Microsoft.Playwright;
using NUnit.Framework;
using ProjectUtilityReporting;
using Reqnroll;

namespace GlideGoWeb.PageObjects
{
    [Binding]
    internal class LoginPage
    {

        private readonly IPage page;

        private const string UsernameInput = "//input[@placeholder='Username']";
        private const string PasswordInput = "//input[@placeholder='Password']";
        private const string LoginButton = "//button[@type='submit']";
        private const string BackButton = "//button[@type='button' and @class='gg-back-btn']";
        private const string ForgotPasswordLink = "//a[@class='rf-login-forgot']";
        private const string EmailWarning = "//div[normalize-space()='The Email field is required.']";
        private const string PasswordWarning = "//div[normalize-space()='The Password field is required.']";
        private const string InvalidLoginWarning = "//div[@class='toaster-rf-title']";
        private const string TermsOfServiceLink = "//a[normalize-space()='Terms of Service']";
        private const string PrivacyPolicyLink = "//a[normalize-space()='Privacy Policy']";
        private const string LoginSuccessTitle = "//div[normalize-space()='New Trip Request']";
        private const string LogoutSuccessText = "//p[@class='gg-form-subtitle']";

        public LoginPage(IPage page)
        {
            this.page = page;
        }

  
        private async Task<ILocator> WaitForVisibleAsync(string locator)
        {
            await page.WaitForSelectorAsync(locator, new PageWaitForSelectorOptions
            {
                Timeout = 5000,
                State = WaitForSelectorState.Visible
            });
            return page.Locator(locator);
        }

        public async Task EnterUsername(string username)
        {
            ExtentReporting.LogInfo($"Enter the Username: {username}");
            await (await WaitForVisibleAsync(UsernameInput)).FillAsync(username);
        }

        public async Task EnterPassword(string password)
        {
            ExtentReporting.LogInfo($"Enter the User Password: {password}");
            await (await WaitForVisibleAsync(PasswordInput)).FillAsync(password);
        }

        public async Task ClickOnLoginButton()
        {
            ExtentReporting.LogInfo("Click on the Login Button");
            await (await WaitForVisibleAsync(LoginButton)).ClickAsync();
        }

        public async Task ClickOnBackButton()
        {
            ExtentReporting.LogInfo("Click on the Back Button of Login Page");
            await (await WaitForVisibleAsync(BackButton)).ClickAsync();
        }

        public async Task ClickOnForgotPassword()
        {
            ExtentReporting.LogInfo("Click on the Forgot Password Link");
            await (await WaitForVisibleAsync(ForgotPasswordLink)).ClickAsync();
        }

        public async Task<bool> IsEmailWarningDisplayed()
        {
            ExtentReporting.LogInfo("Checking if the email warning message is displayed");
            return await (await WaitForVisibleAsync(EmailWarning)).IsVisibleAsync();
        }

        public async Task<bool> IsPasswordWarningDisplayed()
        {
            ExtentReporting.LogInfo("Checking if the password warning message is displayed");
            return await (await WaitForVisibleAsync(PasswordWarning)).IsVisibleAsync();
        }

        public async Task<bool> IsInvalidLoginWarningDisplayed()
        {
            ExtentReporting.LogInfo("Checking if the Invalid Login Warning is displayed");
            string actualResult = await (await WaitForVisibleAsync(InvalidLoginWarning)).InnerTextAsync();
            return actualResult.Equals("Warning");
        }

        public async Task ClickOnTermsOfServices()
        {
            ExtentReporting.LogInfo("Click on the Terms of Service link");
            await (await WaitForVisibleAsync(TermsOfServiceLink)).ClickAsync();
        }

        public async Task ClickOnPrivacyPolicy()
        {
            ExtentReporting.LogInfo("Click on the Privacy Policy link");
            await (await WaitForVisibleAsync(PrivacyPolicyLink)).ClickAsync();
        }

        public async Task<bool> IsLoginSucceed()
        {
            ExtentReporting.LogInfo("Checking if login succeeded");
            string titleUser = await (await WaitForVisibleAsync(LoginSuccessTitle)).InnerTextAsync() ?? string.Empty;
            return titleUser.Equals("New Trip Request");
        }

        public async Task<bool> IsLogoutSucceed()
        {
            ExtentReporting.LogInfo("Checking if logout succeeded");
            string text = await (await WaitForVisibleAsync(LogoutSuccessText)).TextContentAsync() ?? string.Empty;
            return text.Equals("Sign in to continue");
        }


    }
}
