using Aug2024TurnUpPortal.Utilities;
using System;
using TechTalk.SpecFlow;

namespace Aug2024TurnUpPortal.StepDefinition
{
    [Binding]
    public class EmployeeFeatureStepDefinitions : CommonDriver
    {
        [When(@"I navigate to Employee page")]
        public void WhenINavigateToEmployeePage()
        {
            throw new PendingStepException();
        }

        [Given(@"I create a new Employe record")]
        public void GivenICreateANewEmployeRecord()
        {
            throw new PendingStepException();
        }

        [Then(@"I should be able to create the record successfully")]
        public void ThenIShouldBeAbleToCreateTheRecordSuccessfully()
        {
            throw new PendingStepException();
        }

        [Given(@"I update a new Employee page")]
        public void GivenIUpdateANewEmployeePage()
        {
            throw new PendingStepException();
        }

        [Then(@"I should be able to update the record successfully")]
        public void ThenIShouldBeAbleToUpdateTheRecordSuccessfully()
        {
            throw new PendingStepException();
        }

        [Given(@"I delete a new Employee record")]
        public void GivenIDeleteANewEmployeeRecord()
        {
            throw new PendingStepException();
        }

        [Then(@"I should be able to delete the record successfully")]
        public void ThenIShouldBeAbleToDeleteTheRecordSuccessfully()
        {
            throw new PendingStepException();
        }
    }
}
