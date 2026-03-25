using Microsoft.Playwright;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using ProjectUtilityReporting;
using ProjectUtilityScreenShot;


namespace BDD_Project_Playwright_DotNet.Drivers
{
    public class PlaywrightFactory
    {

        public IPlaywright playwright = default!;
        public IBrowser browser = default!;
        public IBrowserContext context = default!;
        public IPage page = default!;


        public async Task<IPage> InitBrowser(string browserName, bool headless = false, int slomotion = 1000)
        {

            var fullClassName = TestContext.CurrentContext.Test.ClassName;
            var ClassName = fullClassName?.Split('.').Last();


            var fullMethodName = TestContext.CurrentContext.Test.MethodName;
            var MethodName = fullMethodName?.Split('.').Last();

            ExtentReporting.CreateTest("WebReport.html", ClassName + " - " + MethodName ?? "Unknown");

            playwright = await Playwright.CreateAsync();

            switch (browserName.ToLower())
            {
                case "chrome":
                    browser = await playwright.Chromium.LaunchAsync(new()
                    {
                        Channel = "chrome",
                        Headless = headless,
                        SlowMo = slomotion,


                    });
                    break;

                case "edge":
                    browser = await playwright.Chromium.LaunchAsync(new()
                    {

                        Channel = "msedge",
                        Headless = headless,
                        SlowMo = slomotion,


                    });
                    break;

                case "firefox":
                    browser = await playwright.Firefox.LaunchAsync(new()
                    {
                        Headless = headless,
                        SlowMo = slomotion,

                    });
                    break;

                case "safari":
                    browser = await playwright.Webkit.LaunchAsync(new()
                    {
                        Headless = headless,
                        SlowMo = slomotion,

                    });
                    break;

                case "chromium":
                    browser = await playwright.Chromium.LaunchAsync(new()
                    {
                        Headless = headless,
                        SlowMo = slomotion,

                    });
                    break;

                default:
                    Console.WriteLine("Incorrect Browser Name.");
                    break;
            }

            context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                Permissions = new[] { "geolocation" }
            });


            page = await context.NewPageAsync();

            await context.ClearCookiesAsync();

            return page;

        }

        public async Task TearDown()
        {

            if (page != null && context !=null && browser !=null && playwright!=null)
            {
                await EndTest();
                ExtentReporting.EndReporting();

                await page.CloseAsync();
                await context.CloseAsync();
                await browser.CloseAsync();
                playwright.Dispose(); 
            }
        }

        private async Task EndTest()
        {
         
            if (page != null)
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

                ExtentReporting.LogScreenshot("Ending Test",await ScreenshotHelper.TakeScreenshotAsync(page, "Element"));
            }


        }

    }

}