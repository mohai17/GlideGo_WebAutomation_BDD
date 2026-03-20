using Microsoft.Playwright;
using ProjectUtilityReporting;
using ProjectUtilityScreenShot;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlideGoWeb.PageObjects
{
    internal class Dashboard
    {
        private readonly IPage page;

     
        private const string ProfileIconLoc = "//html[1]/body[1]/div[1]/div[1]/div[3]/div[1]/div[2]/div[6]/div[2]";
        private const string LogoutButtonLoc = "//a[normalize-space()='Logout']";
        private const string CreateTripLoc = "//button[@class='link-button active']";
        private const string ReviewApprovalLoc = "//button[normalize-space()='Review & Approve']";
        private const string AssignedTripsViewAllLoc = "(//span[normalize-space()='View All'])[2]";
        private const string CompletedTripsViewAllLoc = "(//span[normalize-space()='View All'])[3]";
        private const string SOFManagementLoc = "//button[normalize-space()='Manage Your SOF']";

        public Dashboard(IPage page)
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

        public async Task ClickOnProfileIcon()
        {
            ExtentReporting.LogInfo("Click on the Profile Icon");
            await (await WaitForVisibleAsync(ProfileIconLoc)).ClickAsync();
        }

        public async Task ClickOnLogoutButton()
        {
            ExtentReporting.LogInfo("Click on the logout button");
            await (await WaitForVisibleAsync(LogoutButtonLoc)).ClickAsync();
        }

        public async Task ClickOnCreateNewTrip()
        {
            ExtentReporting.LogInfo("Click on the create new trip");
            await (await WaitForVisibleAsync(CreateTripLoc)).ClickAsync();
        }

        public async Task ClickOnReviewAndApproval()
        {
            ExtentReporting.LogInfo("Click on Review and Approval");
            await (await WaitForVisibleAsync(ReviewApprovalLoc)).ClickAsync();
        }

        public async Task ClickOnAssignedTripsViewAll()
        {
            ExtentReporting.LogInfo("Click on view all of assigned trips");
            var element = await WaitForVisibleAsync(AssignedTripsViewAllLoc);
            await element.ScrollIntoViewIfNeededAsync();
            await element.ClickAsync();
        }

        public async Task ClickOnCompletedTripsViewAll()
        {
            ExtentReporting.LogInfo("Click on view all of completed trips");
            var element = await WaitForVisibleAsync(CompletedTripsViewAllLoc);
            await element.ScrollIntoViewIfNeededAsync();
            await element.ClickAsync();
        }

        public async Task ClickOnSOFManagement()
        {
            ExtentReporting.LogInfo("Click on SOF Management");

            var element = await WaitForVisibleAsync(SOFManagementLoc);
            await element.ScrollIntoViewIfNeededAsync();
            await element.ClickAsync();
        }

    }
}
