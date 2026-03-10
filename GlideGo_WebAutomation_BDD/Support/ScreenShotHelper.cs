using Microsoft.Playwright;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ProjectUtilityScreenShot;
internal class ScreenshotHelper
{
    public static async Task<string> TakeScreenshotAsync(IPage page, string screenshotName)
    {
        string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
        Directory.CreateDirectory(folderPath);

        string filePath = Path.Combine(
            folderPath,
            $"{screenshotName}_{DateTime.Now:yyyyMMdd_HHmmss}.png"
        );

        byte[] bytes = await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = filePath,
            FullPage = true
        });

        return Convert.ToBase64String(bytes);
    }
}
