using Microsoft.Playwright;
using ProjectUtilityReporting;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GlideGoWeb.PageObjects
{
    internal class ChooseDirectionPage
    {

        IPage page;

        public ChooseDirectionPage(IPage page)
        {
            this.page = page;
        }

        public async Task ChooseStartingPoint(string location)
        {
            ExtentReporting.LogInfo($"Choose Starting Point: {location}");
            await page.Locator("//input[@placeholder='Choose starting point...']").FillAsync(location);
     
        }

        public async Task ChooseDestinationPoint(string location)
        {
            ExtentReporting.LogInfo($"Choose Destination Point: {location}");
            await page.Locator("//input[@placeholder='Choose destination...']").FillAsync(location);

        }

        public async Task ChooseAdditionalPoint(string location)
        {
            ExtentReporting.LogInfo($"Choose Additional Point: {location}");
            await page.Locator("//span[normalize-space()='Add destination']").ClickAsync();
            await page.Locator("//input[@placeholder='Choose destination...']").FillAsync(location);
        }

        public async Task ClickOnSendButton()
        {
            ExtentReporting.LogInfo("Click on the send button");
            await page.Locator("//div[@class='routebar-rf-tab-footer-button routebar-rf-tab-footer-button-send False']").ClickAsync();
        }

        public async Task ClickOnFoundLocation()
        {
            ExtentReporting.LogInfo("Click on found location");
            await page.Locator("//div[@class='routebar-rf-location-list']//div[2]//span[1]//span[1]").ClickAsync();
            

        }



    }
}
