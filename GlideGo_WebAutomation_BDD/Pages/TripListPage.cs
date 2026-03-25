using Microsoft.Playwright;
using ProjectUtilityReporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlideGoWeb.PageObjects
{
    internal class TripListPage
    {
        private readonly IPage page;

        private const string AssignedLoc = "//div[@class='option-rf-textarea']//span[contains(text(),'Assigned')]";
        private const string CompletedLoc = "//div[@class='option-rf-textarea']//span[contains(text(),'Completed')]";

        public TripListPage(IPage page)
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

        public async Task FindTripRequestId(string tripId)
        {
            ExtentReporting.LogInfo($"Search Trip Request with ID: {tripId}");
            string tripIdLoc = $"//span[normalize-space()='{tripId}']";
            var element = await WaitForVisibleAsync(tripIdLoc);
            await element.ScrollIntoViewIfNeededAsync();
            await element.ClickAsync();
        }

        public async Task ClickOnAssigned()
        {
            ExtentReporting.LogInfo("Click on Assigned Request");
            await (await WaitForVisibleAsync(AssignedLoc)).ClickAsync();
        }

        public async Task ClickOnCompleted()
        {
            ExtentReporting.LogInfo("Click on Completed Request");
            await (await WaitForVisibleAsync(CompletedLoc)).ClickAsync();
        }

        public async Task<bool> IsTripStatusCompleted(string tripId)
        {
            ExtentReporting.LogInfo($"Checking if Trip Request {tripId} is completely approved");
            string tripStatusLoc = $"//span[normalize-space()='{tripId}']/ancestor::div[3]//span[normalize-space()='Completed']";
            string text = await (await WaitForVisibleAsync(tripStatusLoc)).TextContentAsync() ?? string.Empty;
            return text.Equals("Completed");
        }


    }
}
