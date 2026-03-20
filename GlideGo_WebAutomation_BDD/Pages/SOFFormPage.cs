using Microsoft.Playwright;
using ProjectUtilityReporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GlideGo_WebAutomation_BDD.Pages
{
    internal class SOFFormPage
    {
        IPage page;
        public SOFFormPage(IPage page)
        {
            this.page = page;
            
        }

        private static class Sel
        {
            public const string narrativeLoc = "//form[@method='post']//div[contains(@class,'row')]//div[1]//div[1]//input[1]";
            public const string accountCodeLoc = "//form[@method='post']//div[2]//div[1]//input[1]";
            public const string costCenterDropdownLoc = "//span[normalize-space()='Select Cost Center']";
            public const string costCenterSearchBoxLoc = "//div[@class='select-rf-popper True']//input[@placeholder='Search...']";
            public static string CostCenterCodeLoc(string center) => $"//div[normalize-space()='{center}']";

            public const string projectDropdownLoc = "//span[normalize-space()='Select Project']";
            public const string projectSearchBoxLoc = "//div[@class='select-rf-popper True']//input[@placeholder='Search...']";
            public static string ProjectCodeLoc(string project) => $"//div[normalize-space()='{project}']";

            public const string SOFDropdownLoc = "//span[normalize-space()='Select SOF']";
            public const string SOFSearchBoxLoc = "//div[@class='select-rf-popper True']//input[@placeholder='Search...']";
            public static string SOFCodeLoc(string sof) => $"//div[normalize-space()='{sof}']";

            public const string DRCDropdownLoc = "//span[normalize-space()='Select DRC']";
            public const string DRCSearchBoxLoc = "//div[@class='select-rf-popper True']//input[@placeholder='Search...']";

            public static string DRCCodeLoc(string drc) => $"//div[normalize-space()='{drc}']";

            public const string activityDropdownLoc = "//span[normalize-space()='Select Activity']";
            public const string activitySearchBoxLoc = "//div[@class='select-rf-popper True']//input[@placeholder='Search...']";
            public static string ActivityCodeLoc(string activity) => $"(//div[contains(text(),'{activity}')])[1]";

            public const string budgetHolderDropdownLoc = "//span[normalize-space()='Select Budget Holder']";
            public const string budgetHolderSearchBoxLoc = "//div[@class='select-rf-popper True']//input[@placeholder='Search...']";
            public static string BudgetHolderNameLoc(string name) => $"//div[normalize-space()='{name}']";

            public const string percentageLoc = "//input[@placeholder='Enter Percentage']";
            public const string addSOFButtonLoc = "//span[contains(text(),'Add SOF')]";
            public const string sofNameLoc = "(//div[@class='input-rf']//input[@type='text'])[3]";
            public const string saveButtonLoc = "//span[contains(text(),'Save')]";
            public const string cancelButtonLoc = "//span[normalize-space()='Cancel']";
       

        }

        private ILocator GetLocator(string selector) => page.Locator(selector);

        private static readonly WaitForSelectorState visible = WaitForSelectorState.Visible;
        private const float DefaultTimeout = 5000;

        private async Task WaitVisibleAsync(ILocator locator, float timeout = DefaultTimeout)
        {
            await locator.WaitForAsync(new LocatorWaitForOptions
            {
                State = visible,
                Timeout = timeout
            });
        }

        public async Task EnterNarrative(string narrative)
        {
            ExtentReporting.LogInfo($"Enter the narrative: {narrative}");

            var loc = GetLocator(Sel.narrativeLoc);
            await WaitVisibleAsync(loc);
            await loc.FillAsync(narrative);
        }

        public async Task EnterAccountCode(string accCode)
        {
            ExtentReporting.LogInfo($"Enter the Account Code: {accCode}");
            var loc = GetLocator(Sel.accountCodeLoc);
            await WaitVisibleAsync(loc);
            await loc.FillAsync(accCode);
        }

        public async Task SelectCostCenter(string costCenter)
        {
            ExtentReporting.LogInfo($"Select the cost center: {costCenter}");

            var loc1 = GetLocator(Sel.costCenterDropdownLoc);
            await WaitVisibleAsync(loc1);
            await loc1.ClickAsync();

            var loc2 = GetLocator(Sel.costCenterSearchBoxLoc);
            await WaitVisibleAsync(loc2);
            await loc2.FillAsync(costCenter);

            var loc3 = GetLocator(Sel.CostCenterCodeLoc(costCenter));
            await WaitVisibleAsync(loc3);
            await loc3.ClickAsync();


        }

        public async Task SelectProject(string projectCode)
        {
            ExtentReporting.LogInfo($"Select the project: {projectCode}");

            var loc1 = GetLocator(Sel.projectDropdownLoc);
            await WaitVisibleAsync(loc1);
            await loc1.ClickAsync();

            var loc2 = GetLocator(Sel.projectSearchBoxLoc);
            await WaitVisibleAsync(loc2);
            await loc2.FillAsync(projectCode);

            var loc3 = GetLocator(Sel.ProjectCodeLoc(projectCode));
            await WaitVisibleAsync(loc3);
            await loc3.ClickAsync();
        }

        public async Task SelectSOF(string sofCode)
        {
            ExtentReporting.LogInfo($"Select the SOF: {sofCode}");

            var loc1 = GetLocator(Sel.SOFDropdownLoc);
            await WaitVisibleAsync(loc1);
            await loc1.ClickAsync();

            var loc2 = GetLocator(Sel.SOFSearchBoxLoc);
            await WaitVisibleAsync(loc2);
            await loc2.FillAsync(sofCode);

            var loc3 = GetLocator(Sel.SOFCodeLoc(sofCode));
            await WaitVisibleAsync(loc3);
            await loc3.ClickAsync();

        }

        public async Task SelectDRC(string drc)
        {

            ExtentReporting.LogInfo($"Select the DRC:{drc}");

            var loc1 = GetLocator(Sel.DRCDropdownLoc);
            await WaitVisibleAsync(loc1);
            await loc1.ClickAsync();

            var loc2 = GetLocator(Sel.DRCSearchBoxLoc);
            await WaitVisibleAsync(loc2);
            await loc2.FillAsync(drc);

            var loc3 = GetLocator(Sel.DRCCodeLoc(drc));
            await WaitVisibleAsync(loc3);
            await loc3.ClickAsync();
        }

        public async Task SelectActivity(string activityCode)
        {
            ExtentReporting.LogInfo($"Select the activity: {activityCode}");

            var loc1 = GetLocator(Sel.activityDropdownLoc);
            await WaitVisibleAsync(loc1);
            await loc1.ClickAsync();

            var loc2 = GetLocator(Sel.activitySearchBoxLoc);
            await WaitVisibleAsync(loc2);
            await loc2.FillAsync(activityCode);

            var loc3 = GetLocator(Sel.ActivityCodeLoc(activityCode));
            await WaitVisibleAsync(loc3);
            await loc3.First.ClickAsync();
        }

        public async Task SelectBudgetHolder(string name)
        {
            ExtentReporting.LogInfo($"Select Budget Holder: {name}");

            var loc1 = GetLocator(Sel.budgetHolderDropdownLoc);
            await WaitVisibleAsync(loc1);
            await loc1.ClickAsync();

            var loc2 = GetLocator(Sel.budgetHolderSearchBoxLoc);
            await WaitVisibleAsync(loc2);
            await loc2.FillAsync(name);

            var loc3 = GetLocator(Sel.BudgetHolderNameLoc(name));
            await WaitVisibleAsync(loc3);
            await loc3.ClickAsync();
        }

        public async Task EnterPercentage(string per)
        {
            ExtentReporting.LogInfo($"Enter Percentage: {per}");

            var loc = GetLocator(Sel.percentageLoc);
            await WaitVisibleAsync(loc);
            await loc.ClearAsync();
            await loc.FillAsync(per);
        }

        public async Task ClickOnAddSOFButton()
        {
            ExtentReporting.LogInfo("Click on the Add SOF Button");

            var loc = GetLocator(Sel.addSOFButtonLoc);
            await WaitVisibleAsync(loc);
            await loc.ClickAsync();
        }

        public async Task EnterSOFName(string sofname)
        {
            ExtentReporting.LogInfo($"Enter the SOF Name: {sofname}");

            var loc = GetLocator(Sel.sofNameLoc);
            await WaitVisibleAsync(loc);
            await loc.FillAsync(sofname);
        
        }

        public async Task ClickOnSaveButton()
        {
            ExtentReporting.LogInfo("Click on the Save Button");

            var loc = GetLocator(Sel.saveButtonLoc);
            await WaitVisibleAsync(loc);
            await loc.ClickAsync();
        }

        public async Task ClickOnCancelButton()
        {
            ExtentReporting.LogInfo("Click on the Cancel button");

            var loc = GetLocator(Sel.cancelButtonLoc);
            await WaitVisibleAsync(loc);
            await loc.ClickAsync();
        }
    }
}
