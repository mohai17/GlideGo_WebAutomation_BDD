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
        private const string ToastLoc = "//div[@class='toaster-rf-message']";
        private const string RejectionReasonField = "//textarea[@placeholder='Enter the reason for rejection…']";
        private const string PopUpRejectButton = "//div[@class='modal-rf-button-area']//span[contains(text(),'Reject')]";
        private const string PopUpCancelButton = "//span[normalize-space()='Cancel']";
        private const string RejectionToastLoc = "//div[contains(@class,'toaster-rf-message')]";

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

        public async Task EnterRejectionReason(string reason)
        {
            ExtentReporting.LogInfo($"Enter Rejection Reason: {reason}");
            await (await WaitForVisibleAsync(RejectionReasonField)).FillAsync(reason);
        }

        public async Task ClickOnPopUpRejectButton()
        {
            ExtentReporting.LogInfo("Click on Reject button of the Pop-up");
            await (await WaitForVisibleAsync(PopUpRejectButton)).ClickAsync();
        }

        public async Task ClickOnPopUpCancelButton()
        {
            ExtentReporting.LogInfo("Click on Cancel button of the Pop-up");
            await (await WaitForVisibleAsync(PopUpCancelButton)).ClickAsync();
        }

        public async Task ClickOnTripApprovalList()
        {
            ExtentReporting.LogInfo("Click on the Trip Approval List button");
            await (await WaitForVisibleAsync(TripApprovalListLoc)).ClickAsync();
        }

 

        public async Task<bool> IsSuccessfullyApproved()
        {
            ExtentReporting.LogInfo("Checking, successfully approved or not");
            return await (await WaitForVisibleAsync(ApprovalSuccessLoc)).IsVisibleAsync();
        }

        public async Task<bool> IsSuccessfullyDataSaved()
        {
            ExtentReporting.LogInfo("Checking, successfully data saved toast is displayed or not");
            return await (await WaitForVisibleAsync(ToastLoc)).IsVisibleAsync();
        }

        public async Task<bool> IsSuccessfullyRejected()
        {
            ExtentReporting.LogInfo("Checking, successfully rejected or not");
            return await (await WaitForVisibleAsync(RejectionToastLoc)).IsVisibleAsync();
        }


    }
}
