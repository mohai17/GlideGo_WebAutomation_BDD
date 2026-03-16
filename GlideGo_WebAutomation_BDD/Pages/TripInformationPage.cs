using Microsoft.Playwright;
using ProjectUtilityReporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlideGoWeb.PageObjects
{
    internal class TripInformationPage
    {

        IPage page;

        public TripInformationPage(IPage page)
        {
            this.page = page;
        }


        public async Task ClickOnTripRequestSubmissionButton()
        {
            ExtentReporting.LogInfo("Click on the trip request submission button");
            await page.Locator("//button[@class='btn-next']").ClickAsync();
        }

        public async Task ClickOnTripRequestCancelButton()
        {
            ExtentReporting.LogInfo("Click on the trip request cancel button");
            await page.Locator("//button[@class='btn-cancel']").ClickAsync();
        }

        public async Task<bool> IsSubmissionSucceed()
        {
            ExtentReporting.LogInfo("Checking, Trip Request is successfully submitted or not");
            return await page.Locator("//div[@class='toaster-rf-message']").IsVisibleAsync();
        }

    }
}
