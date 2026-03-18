using Microsoft.Playwright;
using ProjectUtilityReporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlideGoWeb.PageObjects
{
    internal class TripApprovalPage
    {

        private readonly IPage page;


        private const string ApprovalButtonLoc = "//span[normalize-space()='Approve']";
        private const string RejectButtonLoc = "//span[normalize-space()='Reject']";
        private const string TripApprovalListLoc = "//div[@class='modal-rf-button']";
        private const string ApprovalSuccessLoc = "//div[normalize-space()='Trip Request Approved']";


        public TripApprovalPage(IPage page)
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

        public async Task ClickOnApproveButton()
        {
            ExtentReporting.LogInfo("Click on the Approval button");
            await (await WaitForVisibleAsync(ApprovalButtonLoc)).ClickAsync();
        }

        public async Task ClickOnRejectButton()
        {
            ExtentReporting.LogInfo("Click on the Reject button");
            await (await WaitForVisibleAsync(RejectButtonLoc)).ClickAsync();
        }

        public async Task ClickOnTripApprovalList()
        {
            ExtentReporting.LogInfo("Click on the Trip Approval List button");
            await (await WaitForVisibleAsync(TripApprovalListLoc)).ClickAsync();
        }

 

        public async Task<bool> IsSuccessfullyApproved()
        {
            ExtentReporting.LogInfo("Checking if approval success toast is displayed");
            return await (await WaitForVisibleAsync(ApprovalSuccessLoc)).IsVisibleAsync();
        }


    }
}
