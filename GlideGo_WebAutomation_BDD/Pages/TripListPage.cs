using Microsoft.Playwright;
using ProjectUtilityReporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlideGoWeb.PageObjects
{
    internal class TripListPage
    {
        IPage page;
        

        public TripListPage(IPage page)
        {
            this.page = page;

            
        }

        public async Task FindTripRequestId(string tripId)
        {
            ExtentReporting.LogInfo("Search Trip Request");
            var element = page.Locator($"//span[normalize-space()='{tripId}']");
            await element.ScrollIntoViewIfNeededAsync();
            await element.ClickAsync();
        }

        public async Task ClickOnAssigned()
        {
            ExtentReporting.LogInfo("Click on Assigned Request");

            await page.Locator("//div[@class='option-rf-textarea']//span[contains(text(),'Assigned')]").ClickAsync();
        }
        public async Task ClickOnCompleted()
        {
            ExtentReporting.LogInfo("Click on Completed Request");

            await page.Locator("//div[@class='option-rf-textarea']//span[contains(text(),'Completed')]").ClickAsync();
        }
        public async Task<bool> IsTripStatusCompleted(string tripId)
        {
            ExtentReporting.LogInfo("Checking, Trip Request is completly approved or not");
            
            string text = await page.Locator($"//span[normalize-space()='{tripId}']/ancestor::div[3]//span[normalize-space()='Completed']").TextContentAsync() ?? string.Empty;

            if (text.Equals("Completed")) return true;
            else return false;
        }

    }
}
