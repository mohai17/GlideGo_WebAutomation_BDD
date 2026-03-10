using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.Playwright;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using ProjectUtilityReporting;
using ProjectUtilityScreenShot;
using System.IO;
using System.Reflection;

namespace ProjectUtilityReporting
{
    internal class ExtentReporting
    {
        private static ExtentReports extentReports = null!;
        private static ExtentTest extentTest = null!;

        private static ExtentReports StartReporting(string reportName)
        {
            var path = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty,
                @$"..\..\..\..\GlideGo_WebAutomation_BDD\Reports\{reportName}"
            );

            if (extentReports == null)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path)!);

                extentReports = new ExtentReports();
                var sparkReporter = new ExtentSparkReporter(path);

                extentReports.AttachReporter(sparkReporter);
            }

            return extentReports;
        }

        public static void CreateTest(string reportName, string testName)
        {
            extentTest = StartReporting(reportName).CreateTest(testName);
        }

        public static void EndReporting()
        {
            extentReports?.Flush();
        }

        public static void LogInfo(string info)
        {
            extentTest?.Info(info);
        }

        public static void LogPass(string info)
        {
            extentTest?.Pass(info);
        }

        public static void LogFail(string info)
        {
            extentTest?.Fail(info);
        }

        public static void LogScreenshot(string info, string image)
        {
            extentTest?.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }
    }
}


//--------------------------------
//Usage:
//In TearDown---------------------
//await EndTest();
//ExtentReporting.EndReporting();
//---------------------------------
//private async Task EndTest()
//{
//    var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
//    var message = TestContext.CurrentContext.Result.Message;



//    switch (testStatus)
//    {
//        case TestStatus.Failed:
//            ExtentReporting.LogFail($"Test has failed: {message}");
//            break;
//        case TestStatus.Skipped:
//            ExtentReporting.LogInfo($"Test has skipped: {message}");
//            break;
//        case TestStatus.Passed:
//            ExtentReporting.LogPass("Test passed successfully");
//            break;
//    }

//    ExtentReporting.LogScreenshot("Ending Test", await ScreenshotHelper.TakeScreenshotAsync(page, "Element"));

//}