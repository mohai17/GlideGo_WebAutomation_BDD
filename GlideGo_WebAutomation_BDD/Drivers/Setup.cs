using BDD_Project_Playwright_DotNet.Drivers;
using Microsoft.Playwright;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using ProjectUtilityExcel;
using ProjectUtilityPaths;
using ProjectUtilityReporting;
using ProjectUtilityScreenShot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GlideGo_WebAutomation_BDD.Drivers
{
    [Binding]
    public class Setup
    {

        public PlaywrightFactory factory = default!;
        public IPage page = default!;
        public string excelpath = Paths.DataXLSXPath("GlideGoWebData.xlsx") ?? string.Empty;
        public int rowNumberBS;
        public string browserName = "";
        public string url = "";


        [BeforeScenario]
        public async Task BrowserSetup()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            ExcelReaderUtil.PopulateInCollection(excelpath, "BrowserSetup");
            rowNumberBS = Convert.ToInt32(ExcelReaderUtil.ReadData(1, "ConfigRow") ?? string.Empty);
            browserName = ExcelReaderUtil.ReadData(rowNumberBS, "BrowserName") ?? string.Empty;

            url = ExcelReaderUtil.ReadData(rowNumberBS, "URL") ?? string.Empty;

            factory = new PlaywrightFactory();

            
        }

        [AfterScenario]
        public async Task TearDown()
        {
            await EndTest();
            ExtentReporting.EndReporting();

            if (factory?.page != null)

                await factory.page.CloseAsync();

            if (factory?.context != null)
                await factory.context.CloseAsync();

            if (factory?.browser != null)
                await factory.browser.CloseAsync();

            factory?.playwright?.Dispose();


        }

        private async Task EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;



            switch (testStatus)
            {
                case TestStatus.Failed:
                    ExtentReporting.LogFail($"Test has failed: {message}");
                    break;
                case TestStatus.Skipped:
                    ExtentReporting.LogInfo($"Test has skipped: {message}");
                    break;
                case TestStatus.Passed:
                    ExtentReporting.LogPass("Test passed successfully");
                    break;
            }

            //ExtentReporting.LogScreenshot("Ending Test", await ScreenshotHelper.TakeScreenshotAsync(page, "Element"));

            if (factory?.page != null)
            {
                ExtentReporting.LogScreenshot("Ending Test",
                    await ScreenshotHelper.TakeScreenshotAsync(factory.page, "Element"));
            }


        }



    }
}
