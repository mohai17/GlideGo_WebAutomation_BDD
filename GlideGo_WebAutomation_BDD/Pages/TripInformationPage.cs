using Microsoft.Playwright;
using ProjectUtilityReporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlideGoWeb.PageObjects
{
    internal class TripInformationPage
    {

        private readonly IPage page;

        private const string SubmissionButtonLoc = "//button[@class='btn-next']";
        private const string CancelButtonLoc = "//button[@class='btn-cancel']";
        private const string SubmissionSuccessLoc = "//div[@class='toaster-rf-message']";

        public TripInformationPage(IPage page)
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

        public async Task ClickOnTripRequestSubmissionButton()
        {
            ExtentReporting.LogInfo("Click on the trip request submission button");
            var element = await WaitForVisibleAsync(SubmissionButtonLoc);
            await element.ScrollIntoViewIfNeededAsync();
            await element.ClickAsync();
        }

        public async Task ClickOnTripRequestCancelButton()
        {
            ExtentReporting.LogInfo("Click on the trip request cancel button");
            var element = await WaitForVisibleAsync(CancelButtonLoc);
            await element.ScrollIntoViewIfNeededAsync();
            await element.ClickAsync();


        }

        public async Task<bool> IsSubmissionSucceed()
        {
            ExtentReporting.LogInfo("Checking if Trip Request is successfully submitted");
            return await (await WaitForVisibleAsync(SubmissionSuccessLoc)).IsVisibleAsync();

        }


    }
}
