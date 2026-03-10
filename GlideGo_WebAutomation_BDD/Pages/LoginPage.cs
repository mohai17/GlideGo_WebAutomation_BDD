using Microsoft.Playwright;
using NUnit.Framework;
using ProjectUtilityReporting;
using Reqnroll;

namespace GlideGoWeb.PageObjects
{
    [Binding]
    internal class LoginPage
    {

        IPage page = default!;
        public LoginPage(IPage page)
        {
            this.page = page;
        }

        public async Task EnterUsername(string username)
        {
            ExtentReporting.LogInfo($"Enter the Username: {username}");

            await page.Locator("//input[@placeholder='Username']").FillAsync(username);

        }

        public async Task EnterPassword(string password)
        {
            ExtentReporting.LogInfo($"Enter the User Password: {password}");

            await page.Locator("//input[@placeholder='Password']").FillAsync(password);

        }

        public async Task ClickOnLoginButton()
        {
            ExtentReporting.LogInfo("Click on the Login Button");

            await page.Locator("//button[@type='submit']").ClickAsync();

        }

        public async Task ClickOnBackButton()
        {
            ExtentReporting.LogInfo("Enter the Back Button of Login Page");

            await page.Locator("//button[@type='button' and @class='gg-back-btn']").ClickAsync();

        }

        public async Task ClickOnForgotPassword()
        {
            ExtentReporting.LogInfo("Click on the Forgot Password Link");

            await page.Locator("//a[@class='rf-login-forgot']").ClickAsync();

        }

        public async Task<bool> IsEmailWarningDisplayed()
        {
            ExtentReporting.LogInfo("Checking, the email warning message is displayed or not");

            bool result = await page.Locator("//div[normalize-space()='The Email field is required.']").IsVisibleAsync();
            
            return result;
        }

        public async Task<bool> IsPasswordWaringDisplayed()
        {
            ExtentReporting.LogInfo("Checking, the password warning message is displayed or not");

            bool result = await page.Locator("//div[normalize-space()='The Password field is required.']").IsVisibleAsync();

            return result;
        }

        public async Task<bool> IsInvalidLoginWarningDisplayed()
        {
            ExtentReporting.LogInfo("Checking, the Invalid Login Warning is displayed or not");

            string actualResult = await page.Locator("//div[@class='toaster-rf-title']").InnerTextAsync();
            string expectedResult = "Warning";

            bool result = actualResult.Equals(expectedResult);

            return result;
        }

        public async Task ClickOnTermsOfServices()
        {
            ExtentReporting.LogInfo("Click on the Terms of services link");

            await page.Locator("//a[normalize-space()='Terms of Service']").ClickAsync();

        }

        public async Task ClickOnPrivacyPolicy()
        {
            ExtentReporting.LogInfo("Click on the Privacy Policy link");

            await page.Locator("//a[normalize-space()='Privacy Policy']").ClickAsync();

        }

        public async Task<bool> IsLoginSucceed(string userType)
        {
            ExtentReporting.LogInfo("Checking, the login is succeed or not");


            if (userType.ToLower().Equals("user"))
            {
                string titleUser = await page.Locator("//div[normalize-space()='New Trip Request']").InnerTextAsync() ?? string.Empty;
                return titleUser.Equals("New Trip Request");
            }
            else
            {
                string titleAdmin = await page.Locator("//title[normalize-space()='Dashboard']").InnerTextAsync() ?? string.Empty;
                return titleAdmin.Equals("Dashboard");
            }

}

        public async Task<bool> IsLogoutSucceed()
        {

            ExtentReporting.LogInfo("Checking, the logout is succeed or not");

            string text = await page.Locator("//p[@class='gg-form-subtitle']").TextContentAsync() ?? string.Empty;

            return text.Equals("Sign in to continue");
        }

    }
}
