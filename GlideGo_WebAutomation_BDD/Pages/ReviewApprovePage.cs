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
                Timeout = 5000,
                State = WaitForSelectorState.Visible
            });
            return page.Locator(locator);
        }

        public async Task ClickOnTripDetails(string tripId)
        {
            ExtentReporting.LogInfo($"Click on trip details for Trip ID: {tripId}");

            await page.EvaluateAsync("document.body.style.zoom = '70%'");

            string tripDetailsLoc = $"//span[normalize-space()='{tripId}']/ancestor::div[2]//a[normalize-space()='View Details']";

            var element = await WaitForVisibleAsync(tripDetailsLoc);
            await element.ScrollIntoViewIfNeededAsync();
            await element.ClickAsync();
        }

    }
}
