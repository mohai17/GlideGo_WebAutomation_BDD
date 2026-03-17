using GlideGo_WebAutomation_BDD.Drivers;
using ProjectUtilityExcel;
using Reqnroll;
using System;

namespace GlideGo_WebAutomation_BDD.StepDefinitions
{
    [Binding]
    public class TC_004_PendingRequestsApprovalFunctionalityStepDefinitions:Setup
    {


        public TC_004_PendingRequestsApprovalFunctionalityStepDefinitions()
        {

            ExcelReaderUtil.PopulateInCollection(excelpath, "TripApprovalData");

            string row = ExcelReaderUtil.ReadData(1, "ConfigRow") ?? string.Empty;

            string[] rowArray = row.Split('-');
            int arrayLenght = rowArray.Length;

            int[] configRowArray = new int[arrayLenght] ;

            for (int i = 0; i < arrayLenght; i++)
            {
                rowArray[i] = rowArray[i].Trim();
                configRowArray[i] = Convert.ToInt32(rowArray[i]);
            }

            int firstConfigRow = configRowArray[0];
            int lastConfigRow = configRowArray[configRowArray.Length - 1];

            Console.WriteLine("First row: "+firstConfigRow);
            Console.WriteLine("Last row: "+lastConfigRow);




        }

        [Given("a pending request exists")]
        public void GivenAPendingRequestExists()
        {
            throw new PendingStepException();
        }

        [When("the budget holder accepts the pending request")]
        public void WhenTheBudgetHolderAcceptsThePendingRequest()
        {
            throw new PendingStepException();
        }

        [Then("the system updates the request status to Accepted for budget holder")]
        public void ThenTheSystemUpdatesTheRequestStatusToAcceptedForBudgetHolder()
        {
            throw new PendingStepException();
        }

        [Then("the supervisor accepts the pending request")]
        public void ThenTheSupervisorAcceptsThePendingRequest()
        {
            throw new PendingStepException();
        }

        [Then("the system updates the request status to Accepted for supervisor")]
        public void ThenTheSystemUpdatesTheRequestStatusToAcceptedForSupervisor()
        {
            throw new PendingStepException();
        }

        [When("the budget holder rejects the pending request")]
        public void WhenTheBudgetHolderRejectsThePendingRequest()
        {
            throw new PendingStepException();
        }

        [Then("the system updates the request status to Rejected")]
        public void ThenTheSystemUpdatesTheRequestStatusToRejected()
        {
            throw new PendingStepException();
        }

        [When("the budget holder accept the pending request")]
        public void WhenTheBudgetHolderAcceptThePendingRequest()
        {
            throw new PendingStepException();
        }

        [When("the supervisor rejects the pending request")]
        public void WhenTheSupervisorRejectsThePendingRequest()
        {
            throw new PendingStepException();
        }

        [When("the supervisor accepts the pending request")]
        public void WhenTheSupervisorAcceptsThePendingRequest()
        {
            throw new PendingStepException();
        }

    }
}
