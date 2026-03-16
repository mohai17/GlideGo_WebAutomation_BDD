using Microsoft.Playwright;
using ProjectUtilityDateHelper;
using ProjectUtilityReporting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;

namespace GlideGoWeb.PageObjects
{
    internal class TripInformationForm
    {

        IPage page;

        public TripInformationForm(IPage page)
        {
            this.page = page;
        }

        public async Task EnterPurposeOfTravel(string purpose)
        {
            ExtentReporting.LogInfo($"Enter the purpose of travel: {purpose}");
            await page.Locator("//div[contains(@class,'layoutbody-rf')]//div[2]//div[1]//div[1]//input[1]").FillAsync(purpose);
        }

        public async Task ClickOnTypeOfTravel()
        {
            ExtentReporting.LogInfo("Click on the type of travel dropdown");
            await page.Locator("//div[contains(@class,'select-rf-item-text')]").ClickAsync();
        }

        public async Task SearchType(string text)
        {
            ExtentReporting.LogInfo($"Type on the Search box: {text}");
            await page.Locator("//div[@class='select-rf-popper True']//input[@placeholder='Search...']").FillAsync(text);
        }

        public async Task ClickOnType(string type)
        {
            ExtentReporting.LogInfo($"Click on the type which is searched:{type}");
            await page.Locator($"//div[contains(text(),'{type}')]").ClickAsync();
        }
        public async Task ClickOnPickUpDateAndTime()
        {
            ExtentReporting.LogInfo("Click on the Pick up date and time");
            await page.EvaluateAsync("window.scrollBy(0, 50)");
            await page.Locator("//input[contains(@placeholder,'Set Pickup Date & Time')]").ClickAsync();
        }

        public async Task PickUpDateAndTimeSelection(string dateTime)
        {
            ExtentReporting.LogInfo($"Set Pick up date and time selection: {dateTime}");
            var dtSeperation = DateHelper.DateTimeSeparation(dateTime);

            string day = dtSeperation[0];
            string month = dtSeperation[1];
            string year = dtSeperation[2];
            string hours = dtSeperation[4];
            string minutes = dtSeperation[5];
            string seconds = dtSeperation[6];
            string meridiem = dtSeperation[7];

            await page.Locator("//input[@class='datepicker-popup-rf-header-year']").FillAsync(year);
            await page.Locator("//div[@class='datepicker-popup-rf-header-month']").ClickAsync();
            await page.Locator($"//div[normalize-space()='{month}']").ClickAsync();
            await page.Locator($"//td[normalize-space()='{day}']").ClickAsync();
            await page.Locator("//div[@class='datepicker-popup-rf-body-time-inputs']//div[1]//input[1]").FillAsync(hours);
            await page.Locator("//div[@class='datepicker-popup-rf-body-time-inputs']//div[2]//input[1]").FillAsync(minutes);
            await page.Locator("//div[@class='datepicker-popup-rf-body-time-inputs']//div[3]//input[1]").FillAsync(seconds);
            await page.Locator($"//div[normalize-space()='{meridiem.ToUpper()}']").ClickAsync();
            await page.Locator("//div[@class='datepicker-popup-rf-footer-done']").ClickAsync();
            

        }

        public async Task ClickOnDropOffDateAndTime()
        {
            ExtentReporting.LogInfo("Click on the drop off date and time");
            await page.Locator("//input[@placeholder='Set Dropoff Date & Time']").ClickAsync();
            
        }

        public async Task DropOffDateTime(string dateTime)
        {
            ExtentReporting.LogInfo($"Set drip off date time: {dateTime}");

            var dtSeperation = DateHelper.DateTimeSeparation(dateTime);

            string day = dtSeperation[0];
            string month = dtSeperation[1];
            string year = dtSeperation[2];
            string hours12 = dtSeperation[4];
            string minutes = dtSeperation[5];
            string seconds = dtSeperation[6];
            string meridiem = dtSeperation[7];

            
            await page.Locator("//input[@class='datepicker-popup-rf-header-year']").FillAsync(year);
            await page.Locator("//div[@class='datepicker-popup-rf-header-month']").ClickAsync();
            await page.Locator($"//div[normalize-space()='{month}']").ClickAsync();
            await page.Locator($"//td[normalize-space()='{day}']").ClickAsync();
            await page.Locator("//div[@class='datepicker-popup-rf-body-time-inputs']//div[1]//input[1]").FillAsync(hours12);
            await page.Locator("//div[@class='datepicker-popup-rf-body-time-inputs']//div[2]//input[1]").FillAsync(minutes);
            await page.Locator("//div[@class='datepicker-popup-rf-body-time-inputs']//div[3]//input[1]").FillAsync(seconds);
            await page.Locator($"//div[normalize-space()='{meridiem.ToUpper()}']").ClickAsync();
            await page.EvaluateAsync("window.scrollBy(0, 300)");
            await page.Locator("//div[@class='datepicker-popup-rf-footer-done']").ClickAsync();

        }

        public async Task ClickOnLeadPassengerName()
        {
            ExtentReporting.LogInfo("Click on lead passenger name dropdown");
            await page.Locator("//span[normalize-space()=\"Lead Passenger's Name\"]").ClickAsync();
        }

        public async Task SelectLeadPassengerName(string lpname)
        {
            ExtentReporting.LogInfo($"Select lead passenger: {lpname}");
            await page.Locator("//div[@class='select-rf-popper True']//input[@placeholder='Search...']").FillAsync(lpname);
            await page.Locator($"//div[contains(text(),'{lpname}')]").ClickAsync();
        }

        public async Task EnterLeadPassengerPhoneNumber(string lpphone)
        {
            ExtentReporting.LogInfo($"Enter lead passenger phone number: {lpphone}");
            await page.Locator("//div[contains(@class,'form-sub-card')]//div[2]//div[2]//div[1]//input[1]").FillAsync(lpphone);
        }

        public async Task ClickOnLeadPassengerSupervisor()
        {
            ExtentReporting.LogInfo("Click on the lead passenger supervisor");
            await page.Locator("//span[normalize-space()=\"Lead Passenger's Supervisor\"]").ClickAsync();
        }

        public async Task SelectLeadPassengerSupervisor(string lpsname)
        {
            ExtentReporting.LogInfo($"Select lead passenger supervisor: {lpsname}");
            await page.Locator("//div[contains(@class,'select-rf-popper True')]//input[contains(@placeholder,'Search...')]").FillAsync(lpsname);
            await page.Locator($"//div[contains(text(),'{lpsname}')]").ClickAsync();
        }

        public async Task ClickOnOtherSCIPassengerName()
        {
            ExtentReporting.LogInfo("Click on other SCI passenger name");
            await page.Locator("//span[normalize-space()='Other SCI Passenger Name']").ClickAsync();
        }

        public async Task SelectOtherSCIPassengerName(string ospname)
        {
            ExtentReporting.LogInfo($"Select other SCI passenger name: {ospname}");
            await page.Locator("//input[@class='multiselect-rf-popper-input rf-control']").FillAsync(ospname);
            await page.Locator($"//div[contains(text(),'{ospname}')]").ClickAsync();
        }

        public async Task ClickOnAddOtherNonSCIPassenger()
        {
            ExtentReporting.LogInfo("Click on add other Non-SCI passenger");
            await page.Locator("//button[contains(@class,'plus-btn')]//i[contains(@class,'fa-solid fa-plus')]").ClickAsync();
        }

        public async Task EnterNonSCIPassengerName(string nspname)
        {
            ExtentReporting.LogInfo($"Enter Non-SCI passenger name: {nspname}");
            await page.Locator("//input[contains(@placeholder,'Add Other Non-SCI Passenger Name')]").FillAsync(nspname);
        }

        public async Task EnterNonSCIPassengerPhoneNumber(string nspphone)
        {
            ExtentReporting.LogInfo($"Enter Non-SCI passenger phone number: {nspphone}");
            await page.Locator("//input[@placeholder='Enter Phone Number']").FillAsync(nspphone);
        }

        public async Task ClickOnAddPassengerButton()
        {
            ExtentReporting.LogInfo("Click on add passenger button");
            await page.Locator("//button[normalize-space()='Add Passenger']").ClickAsync();
        }

        public async Task ClickOnCancelButtonOfAddPassengerPopup()
        {
            ExtentReporting.LogInfo("Click on cancel button of add passenger popup");
            await page.Locator("//button[contains(@type,'button')][normalize-space()='Cancel']").ClickAsync();
        }
        public async Task ClickOnSourceOfFund()
        {
            ExtentReporting.LogInfo("Click on source of fund");
            await page.Locator("//span[normalize-space()='Select Source of Fund']").ClickAsync();
        }
        public async Task SelectSourceofFund(string fundSource)
        {
            ExtentReporting.LogInfo($"Select source of fund: {fundSource}");
            await page.Locator("//div[contains(@class,'select-rf-popper True')]//input[contains(@placeholder,'Search...')]").FillAsync(fundSource);
            await page.Locator($"//div[contains(text(),'{fundSource}')]").ClickAsync();
        }

        public async Task CheckHeaveyEquipment()
        {
            ExtentReporting.LogInfo("Click on the checkbox of heavey equipment");
            await page.Locator("//input[@id='heavyEquipment']").ClickAsync();
        }

        public async Task EnterDescriptionOfHeavyEquipment(string description)
        {

            ExtentReporting.LogInfo($"Enter the description of Heavy Equipment: {description}");
            await page.Locator("//input[@placeholder='e.g.: Conference presentation equipment, display boards']").FillAsync(description);
        }

        public async Task EnterEstimateWeight(string weight)
        {

            ExtentReporting.LogInfo($"Enter the estimate weight: {weight}");
            await page.Locator("//input[@placeholder='Enter text...']").FillAsync(weight);
        }

        public async Task SelectWeightUnit(string unit)
        {

            ExtentReporting.LogInfo($"Select weight unit: {unit}");

            if (unit.ToLower().Equals("pound"))
            {
                await page.Locator("//span[@class='dropdown-text']").ClickAsync();
                await page.Locator("//div[@class='dropdown-item ']").ClickAsync();
            }
            else
            {
                await page.Locator("//span[@class='dropdown-text']").ClickAsync();
                await page.Locator("//div[@class='dropdown-item active']").ClickAsync();
            }
        }

        public async Task EnterAdditionalComment(string comment)
        {
            ExtentReporting.LogInfo($"Enter the Additional Comment: {comment}");
            await page.Locator("//textarea[@placeholder='e.g.: Enter your comment']").FillAsync(comment);
        }

        public async Task ClickOnNextButton()
        {
            ExtentReporting.LogInfo("Click on the next button");
            await page.Locator("//button[@class='btn-next']").ClickAsync();
        }

        public async Task ClickOnCancelButton()
        {
            ExtentReporting.LogInfo("Click on the cancel button");
            await page.Locator("//button[@class='btn-cancel']").ClickAsync();
        }

        
    }
}
