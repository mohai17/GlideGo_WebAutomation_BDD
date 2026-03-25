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
            public static string SOFCardTitleLoc(string title) => $"//div[@class='card-rf-title' and normalize-space()='{title}']";
            public static string DeleteButtonLoc(string title) => $"//div[@class='card-rf-title' and normalize-space()='{title}']/ancestor::div[@class='card-rf']/following-sibling::div/child::div/child::div[2]";
            public static string EditButtonLoc(string title) => $"//div[@class='card-rf-title' and normalize-space()='{title}']/ancestor::div[@class='card-rf']/following-sibling::div/child::div/child::div[1]";
            

            public const string ConfirmationButtonLoc = "//div[@class='dialog-rf-confirm']";
            public const string CancelButtonLoc = "//div[@class='dialog-rf-cancel']";
            public const string delToastLoc = "//div[@class='toaster-rf-message' and normalize-space()='Data Deleted!']";
        }

        private static readonly WaitForSelectorState Visible = WaitForSelectorState.Visible;
        private const float DefaultTimeout = 30000;

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

        public async Task ClickOnDeleteButton(string title)
        {
            ExtentReporting.LogInfo("Click on the Delete button");

            var loc = GetLocator(Sel.DeleteButtonLoc(title));
            await WaitVisibleAsync(loc);
            await loc.ClickAsync();
        }

        public async Task ClickOnDeleteConfirmation()
        {
            ExtentReporting.LogInfo("Click on Delete Confirmation button");

            var loc = GetLocator(Sel.ConfirmationButtonLoc);
            await WaitVisibleAsync(loc);
            await loc.ClickAsync();
        }


        public async Task ClickOnDeleteCancel()
        {
            ExtentReporting.LogInfo("Click on Delete Cancel button");

            var loc = GetLocator(Sel.CancelButtonLoc);
            await WaitVisibleAsync(loc);
            await loc.ClickAsync();
        }

        public async Task<bool> IsSuccessfullyDeleted()
        {
            ExtentReporting.LogInfo("");

            var loc = GetLocator(Sel.delToastLoc);
            await WaitVisibleAsync(loc);
            return await loc.IsVisibleAsync();

        }

        public async Task ClickOnEditButton(string title)
        {
            ExtentReporting.LogInfo("Click on the Edit button");

            var loc = GetLocator(Sel.EditButtonLoc(title));
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
