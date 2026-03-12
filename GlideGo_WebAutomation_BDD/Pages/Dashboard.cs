using Microsoft.Playwright;
using ProjectUtilityReporting;
using ProjectUtilityScreenShot;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlideGoWeb.PageObjects
{
    internal class Dashboard
    {
        IPage page = default!;
        public Dashboard(IPage page)
        {
            this.page = page;
        }

        public async Task ClickOnProfileIcon()
        {
            ExtentReporting.LogInfo("Click on the Profile Icon");

            Thread.Sleep(2000);

            await page.ReloadAsync();
            await page.WaitForRequestFinishedAsync();
            await page.Locator("//html[1]/body[1]/div[1]/div[1]/div[3]/div[1]/div[2]/div[6]/div[2]").ClickAsync();

        }

        public async Task ClickOnLogoutButton()
        {
            ExtentReporting.LogInfo("Click on the logout button");

            await page.Locator("//a[normalize-space()='Logout']").ClickAsync();
            await page.WaitForRequestFinishedAsync();

        }

        


        

    }
}
