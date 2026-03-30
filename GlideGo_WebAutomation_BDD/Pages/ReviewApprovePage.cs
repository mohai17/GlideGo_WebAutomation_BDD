using Microsoft.Playwright;
using ProjectUtilityReporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlideGoWeb.PageObjects
{
    internal class ReviewApprovePage
    {

        private readonly IPage page;

        public ReviewApprovePage(IPage page)
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

        public async Task ClickOnTripDetails(string tripId)
        {
            ExtentReporting.LogInfo($"Click on trip details for Trip ID: {tripId}");


            string tripDetailsLoc = $"//span[normalize-space()='{tripId}']/ancestor::div[2]//a[normalize-space()='View Details']";

            var locator = await WaitForVisibleAsync(tripDetailsLoc);

            for (int i = 0; i < 20; i++)
            {
                if (await locator.IsVisibleAsync())
                    break;

                await page.EvaluateAsync("window.scrollBy(0, 300)");

                await page.WaitForTimeoutAsync(500);
            }

            await locator.ClickAsync();





        }

    }
}
