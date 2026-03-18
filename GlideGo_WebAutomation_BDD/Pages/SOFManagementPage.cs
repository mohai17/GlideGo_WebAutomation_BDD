using Microsoft.Playwright;
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

        private const string AddSOFLoc = "//span[normalize-space()='Add New SOF']";

        public SOFManagementPage(IPage page)
        {
            this.page = page;
        }

        private static readonly WaitForSelectorState Visible = WaitForSelectorState.Visible;
        private const float DefaultTimeout = 5000;
        private async Task<ILocator> WaitForVisibleAsync(string locator)
        {
            await page.WaitForSelectorAsync(locator, new PageWaitForSelectorOptions
            {
                Timeout = 5000,
                State = WaitForSelectorState.Visible
            });
            return page.Locator(locator);
        }


        public async Task ClickOnAddSOFButton()
        {
            await (await WaitForVisibleAsync(AddSOFLoc)).ClickAsync();
        }



    }
}
