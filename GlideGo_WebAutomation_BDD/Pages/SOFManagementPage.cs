using Microsoft.Playwright;
using ProjectUtilityReporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlideGo_WebAutomation_BDD.Pages
{
    internal class SOFManagementPage
    {
        IPage page;

        
        public SOFManagementPage(IPage page)
        {
            this.page = page;
        }

        
        private static class Sel
        {
            public const string AddSOFLoc = "//span[normalize-space()='Add New SOF']";
            public const string toastLoc = "//div[@class='toaster-rf-message' and normalize-space()='Your SOF has been saved successfully!']";
        }

        private static readonly WaitForSelectorState Visible = WaitForSelectorState.Visible;
        private const float DefaultTimeout = 5000;

        private async Task WaitVisibleAsync(ILocator locator, float timeout = DefaultTimeout)
        {
            await locator.WaitForAsync(new LocatorWaitForOptions
            {
                State = Visible,
                Timeout = timeout
            });
        }

        private ILocator GetLocator(string selector) => page.Locator(selector);

        public async Task ClickOnAddSOFButton()
        {
            ExtentReporting.LogInfo("Click on the Add SOF Button of SOF Management Page");

            var loc = GetLocator(Sel.AddSOFLoc);
            await WaitVisibleAsync(loc);
            await loc.ClickAsync();

        }

        public async Task<bool> IsSOFSuccessfullyCreated()
        {
            ExtentReporting.LogInfo("Checking, SOF Successfully created or not");

            var loc = GetLocator(Sel.toastLoc);
            await WaitVisibleAsync(loc);
            return await loc.IsVisibleAsync();
        }



    }
}
