using AventStack.ExtentReports;
using BDD_Project_Playwright_DotNet.Drivers;
using Microsoft.Playwright;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using ProjectUtilityExcel;
using ProjectUtilityPaths;
using ProjectUtilityReporting;
using ProjectUtilityScreenShot;


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

        public Setup()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [BeforeScenario(Order = 1)]
        public async Task BrowserSetup()
        {

            ExcelReaderUtil.PopulateInCollection(excelpath, "BrowserSetup");
            rowNumberBS = Convert.ToInt32(ExcelReaderUtil.ReadData(1, "ConfigRow") ?? string.Empty);
            browserName = ExcelReaderUtil.ReadData(rowNumberBS, "BrowserName") ?? string.Empty;

            url = ExcelReaderUtil.ReadData(rowNumberBS, "URL") ?? string.Empty;

            factory = new PlaywrightFactory();
            

        }

        [AfterScenario(Order = 1)]
        public async Task AfterScenario()
        {
            
            await factory.TearDown();
            
        }

        



    }
}