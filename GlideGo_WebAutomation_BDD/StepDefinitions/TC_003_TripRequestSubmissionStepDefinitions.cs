using GlideGo_WebAutomation_BDD.Drivers;
using GlideGoWeb.PageObjects;
using Microsoft.Playwright;
using NUnit.Framework;
using ProjectUtilityExcel;
using ProjectUtilityReporting;
using Reqnroll;
using System;
using System.Security.Policy;

namespace GlideGo_WebAutomation_BDD.StepDefinitions
{
    [Binding]
    public class TC_003_TripRequestSubmissionStepDefinitions:Setup
    {
        private int rowNumber;
        private string username;
        private string password;
        private string startingPoint;
        private string destinationPoint;
        private string additionalPoint;
        private string purpose;
        private string type;
        private string pickupDT;
        private string dropOffDT;
        private string leadPassenger;
        private string leadPassengerPhone;
        private string leadPassengerSupervisor;
        private string otherSCIPassenger;
        private string nonSCIPassenger;
        private string nonSCIPassengerPhone;
        private string fundSource;
        private string equipDesc;
        private string weight;
        private string unit;
        private string comment;

        private LoginPage login = default!;
        private PreLoginPage pre = default!;
        private ChooseDirectionPage choose = default!;
        private Dashboard dash = default!;
        private TripInformationForm trip = default!;
        private TripInformationPage tripInfo = default!;

        public TC_003_TripRequestSubmissionStepDefinitions()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            ExcelReaderUtil.PopulateInCollection(excelpath, "TripRequestData");
            rowNumber = Convert.ToInt32(ExcelReaderUtil.ReadData(1, "ConfigRow") ?? string.Empty);

            startingPoint = ExcelReaderUtil.ReadData(rowNumber, "startingPoint") ?? string.Empty;
            destinationPoint = ExcelReaderUtil.ReadData(rowNumber, "destinationPoint") ?? string.Empty;
            additionalPoint = ExcelReaderUtil.ReadData(rowNumber, "additionalPoint") ?? string.Empty;
            username = ExcelReaderUtil.ReadData(rowNumber, "username") ?? string.Empty;
            password = ExcelReaderUtil.ReadData(rowNumber, "password") ?? string.Empty;
            purpose = ExcelReaderUtil.ReadData(rowNumber, "PurposeofTravel") ?? string.Empty;
            type = ExcelReaderUtil.ReadData(rowNumber, "TypeofTravel") ?? string.Empty;
            pickupDT = ExcelReaderUtil.ReadData(rowNumber, "pickupDT") ?? string.Empty;
            dropOffDT = ExcelReaderUtil.ReadData(rowNumber, "dropOffDT") ?? string.Empty;

            leadPassenger = ExcelReaderUtil.ReadData(rowNumber, "leadPassenger") ?? string.Empty;
            leadPassengerPhone = ExcelReaderUtil.ReadData(rowNumber, "leadPassengerPhone") ?? string.Empty;
            leadPassengerSupervisor = ExcelReaderUtil.ReadData(rowNumber, "leadPassengerSupervisor") ?? string.Empty;

            otherSCIPassenger = ExcelReaderUtil.ReadData(rowNumber, "otherSCIPassenger") ?? string.Empty;
            nonSCIPassenger = ExcelReaderUtil.ReadData(rowNumber, "nonSCIPassenger") ?? string.Empty;
            nonSCIPassengerPhone = ExcelReaderUtil.ReadData(rowNumber, "nonSCIPassengerPhone") ?? string.Empty;
            fundSource = ExcelReaderUtil.ReadData(rowNumber, "fundSource") ?? string.Empty;
            equipDesc = ExcelReaderUtil.ReadData(rowNumber, "equipDescription") ?? string.Empty;
            weight = ExcelReaderUtil.ReadData(rowNumber, "weight") ?? string.Empty;
            unit = ExcelReaderUtil.ReadData(rowNumber, "unit") ?? string.Empty;
            comment = ExcelReaderUtil.ReadData(rowNumber, "comment") ?? string.Empty;


        }

        [Given("Open the application and goto the url")]
        public async Task GivenOpenTheApplicationAndGotoTheUrl()
        {

            page = await factory.InitBrowser(browserName);

            login = new LoginPage(page);
            pre = new PreLoginPage(page);
            dash = new Dashboard(page);
            choose = new ChooseDirectionPage(page);
            trip = new TripInformationForm(page);
            tripInfo = new TripInformationPage(page);

            await page.GotoAsync(url);

            ExtentReporting.LogInfo($"Goto the url:{url}");

        }

        [Given("the user is logged into the web app as user")]
        public async Task GivenTheUserIsLoggedIntoTheWebAppAsUser()
        {

            await pre.ClickOnContinueAsGuest();
            await login.EnterUsername(username);
            await login.EnterPassword(password);
            await login.ClickOnLoginButton();
        }

        [When("I have entered a starting point")]
        public async Task WhenIHaveEnteredAStartingPoint()
        {
            await dash.ClickOnCreateNewTrip();
            await choose.ChooseStartingPoint(startingPoint);
            await choose.ClickOnFoundLocation();
        }

        [When("I have entered a destination point")]
        public async Task WhenIHaveEnteredADestinationPoint()
        {
            await choose.ChooseDestinationPoint(destinationPoint);
            await choose.ClickOnFoundLocation();
       
        }

        [When("I add one or more intermediate route points")]
        public async Task WhenIAddOneOrMoreIntermediateRoutePoints()
        {
           
            await choose.ChooseAdditionalPoint(additionalPoint);
            await choose.ClickOnFoundLocation();
            
        }

        [When("I have clicked on the Send button")]
        public async Task WhenIHaveClickedOnNextButton()
        {
            await choose.ClickOnSendButton();
        
        }



        [When("I have provided other essential information")]
        public async Task GivenIHaveProvidedOtherEssentialInformation()
        {

            await trip.EnterPurposeOfTravel(purpose);
            await trip.ClickOnTypeOfTravel();
            await trip.SearchType(type);
            await trip.ClickOnType(type);
            await trip.ClickOnPickUpDateAndTime();
            await trip.PickUpDateAndTimeSelection(pickupDT);
            await trip.ClickOnDropOffDateAndTime();
            await trip.DropOffDateTime(dropOffDT);
            await trip.ClickOnLeadPassengerName();
            await trip.SelectLeadPassengerName(leadPassenger);
            await trip.EnterLeadPassengerPhoneNumber(leadPassengerPhone);
            await trip.ClickOnLeadPassengerSupervisor();
            await trip.SelectLeadPassengerSupervisor(leadPassengerSupervisor);
            await trip.ClickOnOtherSCIPassengerName();
            await trip.SelectOtherSCIPassengerName(otherSCIPassenger);

            await trip.ClickOnAddOtherNonSCIPassenger();
            await trip.EnterNonSCIPassengerName(nonSCIPassenger);
            await trip.EnterNonSCIPassengerPhoneNumber(nonSCIPassengerPhone);
            await trip.ClickOnAddPassengerButton();

            await trip.ClickOnSourceOfFund();
            await trip.SelectSourceofFund(fundSource);
            await trip.CheckHeaveyEquipment();
            await trip.EnterDescriptionOfHeavyEquipment(equipDesc);
            await trip.EnterEstimateWeight(weight);
            await trip.SelectWeightUnit(unit);
            await trip.EnterAdditionalComment(comment);
            await trip.ClickOnNextButton();

        }

        [When("I submit the trip request")]
        public async Task WhenISubmitTheTripRequest()
        {

            await tripInfo.ClickOnTripRequestSubmissionButton();

        }

        [Then("the trip request should be created successfully")]
        public async Task ThenTheTripRequestShouldBeCreatedSuccessfully()
        {
            bool actualResult = await tripInfo.IsSubmissionSucceed();
            Assert.That(actualResult, Is.True);
        }


    }
}
