using Microsoft.Playwright;
using ProjectUtilityReporting;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GlideGoWeb.PageObjects
{
    internal class ChooseDirectionPage
    {

        private readonly IPage page;

     
        private const string StartingPointInput = "//input[@placeholder='Choose starting point...']";
        private const string DestinationPointInput = "//input[@placeholder='Choose destination...']";
        private const string AddDestinationButton = "//span[normalize-space()='Add destination']";
        private const string NextButton = "//div[@class='routebar-rf-tab-footer-button routebar-rf-tab-footer-button-send False']";
        private const string FoundLocationButton = "//div[@class='routebar-rf-location-list']//div[2]//span[1]//span[1]";
        private const string MapLodingLoc = "div.leaflet-tile-container img.leaflet-tile";
        public ChooseDirectionPage(IPage page)
        {
            this.page = page;
        }

     
        private async Task<ILocator> WaitForVisibleAsync(string locator)
        {
            await page.WaitForSelectorAsync(locator, new PageWaitForSelectorOptions
            {
                Timeout = 30000,
                State = WaitForSelectorState.Visible
            });
            return page.Locator(locator);
        }

        public async Task ChooseStartingPoint(string location)
        {
            ExtentReporting.LogInfo($"Choose Starting Point: {location}");
            await (await WaitForVisibleAsync(StartingPointInput)).FillAsync(location);
            
         
        }

        public async Task ChooseDestinationPoint(string location)
        {
            ExtentReporting.LogInfo($"Choose Destination Point: {location}");
            await (await WaitForVisibleAsync(DestinationPointInput)).FillAsync(location);
        }

        public async Task ChooseAdditionalPoint(string location)
        {
            ExtentReporting.LogInfo($"Choose Additional Point: {location}");
            await (await WaitForVisibleAsync(AddDestinationButton)).ClickAsync();
            await (await WaitForVisibleAsync(DestinationPointInput)).FillAsync(location);
        
        }

        public async Task ClickOnSendButton()
        {
            ExtentReporting.LogInfo("Click on the send button");
            await Task.Delay(4000);
            await (await WaitForVisibleAsync(NextButton)).ClickAsync();
        }

        public async Task ClickOnFoundLocation()
        {
            ExtentReporting.LogInfo("Click on found location");

            await (await WaitForVisibleAsync(FoundLocationButton)).ClickAsync();
            await page.WaitForSelectorAsync(MapLodingLoc,
                            new() { State = WaitForSelectorState.Visible, Timeout = 10000 });

            await Task.Delay(1000);

        }


    }
}
