using Microsoft.Playwright;
using ProjectUtilityReporting;
using ProjectUtilityScreenShot;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlideGoWeb.PageObjects
{
    internal class PreLoginPage
    {

        private readonly IPage page;

        private const string LangDropDownLoc = "//button[@class='gg-lang-btn']";
        private const string SignInWithSSOLoc = "//button[@class='gg-submit-btn']";
        private const string ContinueAsGuestLoc = "//button[@class='gg-back-btn']";
        private const string PreLoginTextLoc = "//p[normalize-space()='Sign in to continue']";

        public PreLoginPage(IPage page)
        {
            this.page = page;
        }

        private async Task<ILocator> WaitForVisibleAsync(string locator)
        {
            await page.WaitForSelectorAsync(locator, new PageWaitForSelectorOptions
            {
                Timeout = 10000,
                State = WaitForSelectorState.Visible
            });
            return page.Locator(locator);
        }

        public async Task ClickOnLangDropDown()
        {
            ExtentReporting.LogInfo("Click on the Language Dropdown");
            await (await WaitForVisibleAsync(LangDropDownLoc)).ClickAsync();
            ExtentReporting.LogScreenshot("Language Dropdown", await ScreenshotHelper.TakeScreenshotAsync(page, "LangDropdown"));
        }

        public async Task ClickOnSignInWithSSO()
        {
            ExtentReporting.LogInfo("Click on the Sign in with SSO button");
            await (await WaitForVisibleAsync(SignInWithSSOLoc)).ClickAsync();
            ExtentReporting.LogScreenshot("SSO Button", await ScreenshotHelper.TakeScreenshotAsync(page, "SSOButton"));
        }

        public async Task ClickOnContinueAsGuest()
        {
            ExtentReporting.LogInfo("Click on the continue as guest button");
            await (await WaitForVisibleAsync(ContinueAsGuestLoc)).ClickAsync();
        }

        public async Task<bool> IsItPreLoginPage()
        {
            ExtentReporting.LogInfo("Checking if user remains on the prelogin page");
            string text = await (await WaitForVisibleAsync(PreLoginTextLoc)).InnerTextAsync() ?? string.Empty;
            return text.Equals("Sign in to continue");
        }



    }
}
