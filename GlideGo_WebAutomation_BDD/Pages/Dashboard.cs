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

            await page.Locator("//div[@class='rf-page-header-action-item-userletter']").ClickAsync();

        }

        public async Task ClickOnLogoutButton()
        {
            ExtentReporting.LogInfo("Click on the logout button");

            await page.Locator("//a[normalize-space()='Logout']").ClickAsync();

        }

        


        

    }
}
