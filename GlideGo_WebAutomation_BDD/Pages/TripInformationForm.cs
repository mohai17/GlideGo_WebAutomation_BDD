using Microsoft.Playwright;
using ProjectUtilityDateHelper;
using ProjectUtilityReporting;


namespace GlideGoWeb.PageObjects
{
    internal class TripInformationForm
    {


        private readonly IPage page;

        private static class Sel
        {
            public const string PurposeOfTravelInput = "//div[contains(@class,'layoutbody-rf')]//div[2]//div[1]//div[1]//input[1]";
            public const string TypeOfTravelDropdown = "//div[contains(@class,'select-rf-item-text')]";
            public const string TypeSearchInput = "//div[@class='select-rf-popper True']//input[@placeholder='Search...']";
            public static string TypeItem(string type) => $"//div[contains(text(),'{type}')]";

            public const string PickupDateTimeInput = "//input[contains(@placeholder,'Set Pickup Date & Time')]";
            public const string DatepickerYearInput = "//input[@class='datepicker-popup-rf-header-year']";
            public const string DatepickerMonthHeader = "//div[@class='datepicker-popup-rf-header-month']";
            public static string MonthItem(string month) => $"//div[normalize-space()='{month}']";
            public static string DayCell(string day) => $"//td[normalize-space()='{day}']";
            public const string TimeHoursInput = "//div[@class='datepicker-popup-rf-body-time-inputs']//div[1]//input[1]";
            public const string TimeMinutesInput = "//div[@class='datepicker-popup-rf-body-time-inputs']//div[2]//input[1]";
            public const string TimeSecondsInput = "//div[@class='datepicker-popup-rf-body-time-inputs']//div[3]//input[1]";
            public static string Meridiem(string meridiem) => $"//div[normalize-space()='{meridiem.ToUpper()}']";
            public const string DatepickerDone = "//div[@class='datepicker-popup-rf-footer-done']";

            public const string DropoffDateTimeInput = "//input[@placeholder='Set Dropoff Date & Time']";

            public const string LeadPassengerNameDropdown = "//span[normalize-space()=\"Lead Passenger's Name\"]";
            public const string LeadPassengerSearchInput = "//div[@class='select-rf-popper True']//input[@placeholder='Search...']";
            public static string LeadPassengerItem(string name) => $"//div[contains(text(),'{name}')]";

            public const string LeadPassengerPhoneInput = "//div[contains(@class,'form-sub-card')]//div[2]//div[2]//div[1]//input[1]";

            public const string LeadPassengerSupervisorDropdown = "//span[normalize-space()=\"Lead Passenger's Supervisor\"]";
            public const string LeadPassengerSupervisorSearchInput = "//div[contains(@class,'select-rf-popper True')]//input[contains(@placeholder,'Search...')]";
            public static string LeadPassengerSupervisorItem(string name) => $"//div[contains(text(),'{name}')]";

            public const string OtherSCIPassengerDropdown = "//span[normalize-space()='Other SCI Passenger Name']";
            public const string OtherSCIPassengerSearchInput = "//input[@class='multiselect-rf-popper-input rf-control']";
            public static string OtherSCIPassengerItem(string name) => $"//div[contains(text(),'{name}')]";

            public const string AddOtherNonSCIPassengerBtn = "//button[contains(@class,'plus-btn')]//i[contains(@class,'fa-solid fa-plus')]";
            public const string NonSCIPassengerNameInput = "//input[contains(@placeholder,'Add Other Non-SCI Passenger Name')]";
            public const string NonSCIPassengerPhoneInput = "//input[@placeholder='Enter Phone Number']";
            public const string AddPassengerBtn = "//button[normalize-space()='Add Passenger']";
            public const string CancelAddPassengerBtn = "//button[contains(@type,'button')][normalize-space()='Cancel']";

            public const string SourceOfFundDropdown = "//span[normalize-space()='Select Source of Fund']";
            public const string SourceOfFundSearchInput = "//div[contains(@class,'select-rf-popper True')]//input[contains(@placeholder,'Search...')]";
            public static string SourceOfFundItem(string text) => $"//div[contains(text(),'{text}')]";

            public const string HeavyEquipmentCheckbox = "//input[@id='heavyEquipment']";
            public const string HeavyEquipmentDescriptionInput = "//input[@placeholder='e.g.: Conference presentation equipment, display boards']";
            public const string EstimateWeightInput = "//input[@placeholder='Enter text...']";
            public const string WeightUnitDropdownText = "//span[@class='dropdown-text']";
            public const string WeightUnitPoundItem = "//div[@class='dropdown-item ']";
            public const string WeightUnitKgItem = "//div[@class='dropdown-item active']";

            public const string AdditionalCommentTextarea = "//textarea[@placeholder='e.g.: Enter your comment']";
            public const string NextButton = "//button[@class='btn-next']";
            public const string CancelButton = "//button[@class='btn-cancel']";
        }

    
        private static readonly WaitForSelectorState Visible = WaitForSelectorState.Visible;
        private const float DefaultTimeout = 5000;

        private async Task WaitVisibleAsync(ILocator locator, float timeout = DefaultTimeout)
        {
            await locator.WaitForAsync(new LocatorWaitForOptions
            {
                State = Visible,
                Timeout = timeout
            });
        }

        private ILocator L(string selector) => page.Locator(selector);

        public TripInformationForm(IPage page)
        {
            this.page = page;
        }


        public async Task EnterPurposeOfTravel(string purpose)
        {
            ExtentReporting.LogInfo($"Enter the purpose of travel: {purpose}");
            var loc = L(Sel.PurposeOfTravelInput);
            await WaitVisibleAsync(loc);
            await loc.FillAsync(purpose);
        }

        public async Task ClickOnTypeOfTravel()
        {
            ExtentReporting.LogInfo("Click on the type of travel dropdown");
            var loc = L(Sel.TypeOfTravelDropdown);
            await WaitVisibleAsync(loc);
            await loc.ClickAsync();
        }

        public async Task SearchType(string text)
        {
            ExtentReporting.LogInfo($"Type on the Search box: {text}");
            var loc = L(Sel.TypeSearchInput);
            await WaitVisibleAsync(loc);
            await loc.FillAsync(text);
        }

        public async Task ClickOnType(string type)
        {
            ExtentReporting.LogInfo($"Click on the type which is searched: {type}");
            var loc = L(Sel.TypeItem(type));
            await WaitVisibleAsync(loc);
            await loc.ClickAsync();
        }

        public async Task ClickOnPickUpDateAndTime()
        {
            ExtentReporting.LogInfo("Click on the Pick up date and time");
            await page.EvaluateAsync("window.scrollBy(0, 50)");
            var loc = L(Sel.PickupDateTimeInput);
            await WaitVisibleAsync(loc);
            await loc.ClickAsync();
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

            var yearInput = L(Sel.DatepickerYearInput);
            await WaitVisibleAsync(yearInput);
            await yearInput.FillAsync(year);

            var monthHeader = L(Sel.DatepickerMonthHeader);
            await WaitVisibleAsync(monthHeader);
            await monthHeader.ClickAsync();

            var monthItem = L(Sel.MonthItem(month));
            await WaitVisibleAsync(monthItem);
            await monthItem.ClickAsync();

            var dayCell = L(Sel.DayCell(day));
            await WaitVisibleAsync(dayCell);
            await dayCell.ClickAsync();

            var hoursInput = L(Sel.TimeHoursInput);
            await WaitVisibleAsync(hoursInput);
            await hoursInput.FillAsync(hours);

            var minutesInput = L(Sel.TimeMinutesInput);
            await WaitVisibleAsync(minutesInput);
            await minutesInput.FillAsync(minutes);

            var secondsInput = L(Sel.TimeSecondsInput);
            await WaitVisibleAsync(secondsInput);
            await secondsInput.FillAsync(seconds);

            var meridiemBtn = L(Sel.Meridiem(meridiem));
            await WaitVisibleAsync(meridiemBtn);
            await meridiemBtn.ClickAsync();

            var doneBtn = L(Sel.DatepickerDone);
            await WaitVisibleAsync(doneBtn);
            await doneBtn.ClickAsync();
        }

        public async Task ClickOnDropOffDateAndTime()
        {
            ExtentReporting.LogInfo("Click on the drop off date and time");
            var loc = L(Sel.DropoffDateTimeInput);
            await WaitVisibleAsync(loc);
            await loc.ClickAsync();
        }

        public async Task DropOffDateTime(string dateTime)
        {
            ExtentReporting.LogInfo($"Set drop off date time: {dateTime}");

            var dtSeperation = DateHelper.DateTimeSeparation(dateTime);

            string day = dtSeperation[0];
            string month = dtSeperation[1];
            string year = dtSeperation[2];
            string hours12 = dtSeperation[4];
            string minutes = dtSeperation[5];
            string seconds = dtSeperation[6];
            string meridiem = dtSeperation[7];

            var yearInput = L(Sel.DatepickerYearInput);
            await WaitVisibleAsync(yearInput);
            await yearInput.FillAsync(year);

            var monthHeader = L(Sel.DatepickerMonthHeader);
            await WaitVisibleAsync(monthHeader);
            await monthHeader.ClickAsync();

            var monthItem = L(Sel.MonthItem(month));
            await WaitVisibleAsync(monthItem);
            await monthItem.ClickAsync();

            var dayCell = L(Sel.DayCell(day));
            await WaitVisibleAsync(dayCell);
            await dayCell.ClickAsync();

            var hoursInput = L(Sel.TimeHoursInput);
            await WaitVisibleAsync(hoursInput);
            await hoursInput.FillAsync(hours12);

            var minutesInput = L(Sel.TimeMinutesInput);
            await WaitVisibleAsync(minutesInput);
            await minutesInput.FillAsync(minutes);

            var secondsInput = L(Sel.TimeSecondsInput);
            await WaitVisibleAsync(secondsInput);
            await secondsInput.FillAsync(seconds);

            var meridiemBtn = L(Sel.Meridiem(meridiem));
            await WaitVisibleAsync(meridiemBtn);
            await meridiemBtn.ClickAsync();

            await page.EvaluateAsync("window.scrollBy(0, 300)");

            var doneBtn = L(Sel.DatepickerDone);
            await WaitVisibleAsync(doneBtn);
            await doneBtn.ClickAsync();
        }

        public async Task ClickOnLeadPassengerName()
        {
            ExtentReporting.LogInfo("Click on lead passenger name dropdown");
            var loc = L(Sel.LeadPassengerNameDropdown);
            await WaitVisibleAsync(loc);
            await loc.ClickAsync();
        }

        public async Task SelectLeadPassengerName(string lpname)
        {
            ExtentReporting.LogInfo($"Select lead passenger: {lpname}");
            var search = L(Sel.LeadPassengerSearchInput);
            await WaitVisibleAsync(search);
            await search.FillAsync(lpname);

            var item = L(Sel.LeadPassengerItem(lpname));
            await WaitVisibleAsync(item);
            await item.ClickAsync();
        }

        public async Task EnterLeadPassengerPhoneNumber(string lpphone)
        {
            ExtentReporting.LogInfo($"Enter lead passenger phone number: {lpphone}");
            var loc = L(Sel.LeadPassengerPhoneInput);
            await WaitVisibleAsync(loc);
            await loc.FillAsync(lpphone);
        }

        public async Task ClickOnLeadPassengerSupervisor()
        {
            ExtentReporting.LogInfo("Click on the lead passenger supervisor");
            var loc = L(Sel.LeadPassengerSupervisorDropdown);
            await WaitVisibleAsync(loc);
            await loc.ClickAsync();
        }

        public async Task SelectLeadPassengerSupervisor(string lpsname)
        {
            ExtentReporting.LogInfo($"Select lead passenger supervisor: {lpsname}");
            var search = L(Sel.LeadPassengerSupervisorSearchInput);
            await WaitVisibleAsync(search);
            await search.FillAsync(lpsname);

            var item = L(Sel.LeadPassengerSupervisorItem(lpsname));
            await WaitVisibleAsync(item);
            await item.ClickAsync();
        }

        public async Task ClickOnOtherSCIPassengerName()
        {
            ExtentReporting.LogInfo("Click on other SCI passenger name");
            var loc = L(Sel.OtherSCIPassengerDropdown);
            await WaitVisibleAsync(loc);
            await loc.ClickAsync();
        }

        public async Task SelectOtherSCIPassengerName(string ospname)
        {
            ExtentReporting.LogInfo($"Select other SCI passenger name: {ospname}");
            var search = L(Sel.OtherSCIPassengerSearchInput);
            await WaitVisibleAsync(search);
            await search.FillAsync(ospname);

            var item = L(Sel.OtherSCIPassengerItem(ospname));
            await WaitVisibleAsync(item);
            await item.ClickAsync();
        }

        public async Task ClickOnAddOtherNonSCIPassenger()
        {
            ExtentReporting.LogInfo("Click on add other Non-SCI passenger");
            var btn = L(Sel.AddOtherNonSCIPassengerBtn);
            await WaitVisibleAsync(btn);
            await btn.ClickAsync();
        }

        public async Task EnterNonSCIPassengerName(string nspname)
        {
            ExtentReporting.LogInfo($"Enter Non-SCI passenger name: {nspname}");
            var loc = L(Sel.NonSCIPassengerNameInput);
            await WaitVisibleAsync(loc);
            await loc.FillAsync(nspname);
        }

        public async Task EnterNonSCIPassengerPhoneNumber(string nspphone)
        {
            ExtentReporting.LogInfo($"Enter Non-SCI passenger phone number: {nspphone}");
            var loc = L(Sel.NonSCIPassengerPhoneInput);
            await WaitVisibleAsync(loc);
            await loc.FillAsync(nspphone);
        }

        public async Task ClickOnAddPassengerButton()
        {
            ExtentReporting.LogInfo("Click on add passenger button");
            var btn = L(Sel.AddPassengerBtn);
            await WaitVisibleAsync(btn);
            await btn.ClickAsync();
        }

        public async Task ClickOnCancelButtonOfAddPassengerPopup()
        {
            ExtentReporting.LogInfo("Click on cancel button of add passenger popup");
            var btn = L(Sel.CancelAddPassengerBtn);
            await WaitVisibleAsync(btn);
            await btn.ClickAsync();
        }

        public async Task ClickOnSourceOfFund()
        {
            ExtentReporting.LogInfo("Click on source of fund");
            var dropdown = L(Sel.SourceOfFundDropdown);
            await WaitVisibleAsync(dropdown);
            await dropdown.ClickAsync();
        }

        public async Task SelectSourceofFund(string fundSource)
        {
            ExtentReporting.LogInfo($"Select source of fund: {fundSource}");
            var search = L(Sel.SourceOfFundSearchInput);
            await WaitVisibleAsync(search);
            await search.FillAsync(fundSource);

            var item = L(Sel.SourceOfFundItem(fundSource));
            await WaitVisibleAsync(item);
            await item.ClickAsync();
        }

        public async Task CheckHeaveyEquipment()
        {
            ExtentReporting.LogInfo("Click on the checkbox of heavy equipment");
            var checkbox = L(Sel.HeavyEquipmentCheckbox);
            await WaitVisibleAsync(checkbox);
            await checkbox.ClickAsync();
        }

        public async Task EnterDescriptionOfHeavyEquipment(string description)
        {
            ExtentReporting.LogInfo($"Enter the description of Heavy Equipment: {description}");
            var loc = L(Sel.HeavyEquipmentDescriptionInput);
            await WaitVisibleAsync(loc);
            await loc.FillAsync(description);
        }

        public async Task EnterEstimateWeight(string weight)
        {
            ExtentReporting.LogInfo($"Enter the estimate weight: {weight}");
            var loc = L(Sel.EstimateWeightInput);
            await WaitVisibleAsync(loc);
            await loc.FillAsync(weight);
        }

        public async Task SelectWeightUnit(string unit)
        {
            ExtentReporting.LogInfo($"Select weight unit: {unit}");
            var dropdown = L(Sel.WeightUnitDropdownText);
            await WaitVisibleAsync(dropdown);
            await dropdown.ClickAsync();

            if (unit?.Trim().ToLower() == "pound")
            {
                var poundItem = L(Sel.WeightUnitPoundItem);
                await WaitVisibleAsync(poundItem);
                await poundItem.ClickAsync();
            }
            else
            {
                var kgItem = L(Sel.WeightUnitKgItem);
                await WaitVisibleAsync(kgItem);
                await kgItem.ClickAsync();
            }
        }

        public async Task EnterAdditionalComment(string comment)
        {
            ExtentReporting.LogInfo($"Enter the Additional Comment: {comment}");
            var loc = L(Sel.AdditionalCommentTextarea);
            await WaitVisibleAsync(loc);
            await loc.FillAsync(comment);
        }

        public async Task ClickOnNextButton()
        {
            ExtentReporting.LogInfo("Click on the next button");
            var btn = L(Sel.NextButton);
            await WaitVisibleAsync(btn);
            await btn.ClickAsync();
        }

        public async Task ClickOnCancelButton()
        {
            ExtentReporting.LogInfo("Click on the cancel button");
            var btn = L(Sel.CancelButton);
            await WaitVisibleAsync(btn);
            await btn.ClickAsync();
        }



    }
}
