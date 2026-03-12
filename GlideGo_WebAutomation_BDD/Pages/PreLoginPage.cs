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

        IPage page = default!;


        public PreLoginPage(IPage page)
        {
            this.page = page;
        }

        public async Task ClickOnLangDropDown()
        {
            ExtentReporting.LogInfo("Click on the Language Dropdown");
            await page.Locator("//button[@class='gg-lang-btn']").ClickAsync();

            ExtentReporting.LogScreenshot("Test", await ScreenshotHelper.TakeScreenshotAsync(page, "Element"));


        }

        public async Task ClickOnSignInWithSSO()
        {
            ExtentReporting.LogInfo("Click on the Sign in with SSO button");
            await page.Locator("//button[@class='gg-submit-btn']").ClickAsync();

            ExtentReporting.LogScreenshot("Test", await ScreenshotHelper.TakeScreenshotAsync(page, "Element"));

        }

        public async Task ClickOnContinueAsGuest()
        {
            ExtentReporting.LogInfo("Click on the continue as guest button");
            await page.Locator("//button[@class='gg-back-btn']").ClickAsync();

        }

        public async Task<bool> IsItPreLoginPage()
        {
            ExtentReporting.LogInfo("Checking, User remains on the prelogin page or not");

            string text = await page.Locator("//p[normalize-space()='Sign in to continue']").InnerTextAsync();

            return text.Equals("Sign in to continue");
            
        }


    }
}
