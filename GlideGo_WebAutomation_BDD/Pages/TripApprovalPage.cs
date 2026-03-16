using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlideGoWeb.PageObjects
{
    internal class TripApprovalPage
    {

        IPage page;
        
        public TripApprovalPage(IPage page)
        {
            this.page = page;
        }

        public async Task ClickOnApprovalButton()
        {

            await page.Locator("//span[normalize-space()='Approve']").ClickAsync();

        }

        public async Task ClickOnRejectButton()
        {

            await page.Locator("//span[normalize-space()='Reject']").ClickAsync();

        }

        public async Task ClickOnTripApprovalList()
        {
            await page.Locator("//div[@class='modal-rf-button']").ClickAsync();
        }

        public async Task<bool> IsSuccessfullyApproved()
        {

            return await page.Locator("//div[@class='toaster-rf-title']").IsVisibleAsync();

        }

    }
}
