using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_Project_Playwright_DotNet.Drivers
{
    public class PlaywrightFactory
    {

        public IPlaywright playwright = default!;
        public IBrowser browser = default!;
        public IBrowserContext context = default!;
        public IPage page = default!;


        public async Task<IPage> InitBrowser(string browserName, bool headless=false, int slomotion=1000)
        {

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

            context = await browser.NewContextAsync();
         

            page = await browser.NewPageAsync();

            return page;

        }

    }

}
