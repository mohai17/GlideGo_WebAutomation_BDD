using Microsoft.Playwright;
using ProjectUtilityReporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlideGoWeb.PageObjects
{
    internal class ReviewApprovePage
    {

        IPage page;

        public ReviewApprovePage(IPage page)
        {
            this.page = page;
        }

        public async Task ClickOnTripDetails(string tripId)
        {
            ExtentReporting.LogInfo("Click on trip details");
            await page.EvaluateAsync("document.body.style.zoom = '70%'");
            await page.Locator($"//span[normalize-space()='{tripId}']/ancestor::div[2]//a[normalize-space()='View Details']").ClickAsync();
        }

    }
}
