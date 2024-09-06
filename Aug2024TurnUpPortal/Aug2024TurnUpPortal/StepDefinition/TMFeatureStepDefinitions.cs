using Aug2024TurnUpPortal.Pages;
using Aug2024TurnUpPortal.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Aug2024TurnUpPortal.StepDefinition
{

    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TMPage tMPageObj = new TMPage();

        [Given(@"I logged into TurnUp portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
            //open Chrome Browser
            driver = new ChromeDriver();

            //Login page object initialization and definition

            loginPageObj.LoginActions(driver);
        }

        [Given(@"I logged into TurnUp portal successfully using '([^']*)' and '([^']*)'")]
        public void GivenILoggedIntoTurnUpPortalSuccessfullyUsingAnd(string userName, string password)
        {

            //open Chrome Browser
            driver = new ChromeDriver();

            //Login page object initialization and definition

            loginPageObj.LoginActions(driver);
        }

        [When(@"I navigate to Time and Material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            //Home page object initialization and definition : Navigate TO TM Page

            homePageObj.NavigateTOTMPage(driver);
        }

        [When(@"I create a time record '([^']*)', '([^']*)', '([^']*)' and '([^']*)'")]
        public void WhenICreateATimeRecordAnd(string typeCode, string code, string description, string price)
        {
            tMPageObj.CreateTimeRecord(driver, typeCode, code, description, price);
        }     

        [When(@"I update the '([^']*)', '([^']*)', '([^']*)' and '([^']*)' on an existing Time record")]
        public void WhenIUpdateTheAndOnAnExistingTimeRecord(string  typeCode, string code, string description, string price)
        {
            tMPageObj.EditTimeRocord(driver, typeCode, code, description, price);
        }

        [Then(@"the record should have the (created|updated) '([^']*)', '([^']*)', '([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdatedAnd(string option, string typecode,string code, string description, string price)
        {
            string editedTypeCode = tMPageObj.GetEditedTypeCode(driver);
            string editedCode = tMPageObj.GetEditedCode(driver);
            string editedDescription = tMPageObj.GetEditedDescription(driver);
            string editedPrice = tMPageObj.GetEditedPrice(driver);

            Assert.That(editedTypeCode == typecode, "Type code record has not been updated");
            Assert.That(editedCode == code, "Time record has not been updated");
            Assert.That(editedDescription == description, "Description record has not been updated");
            Assert.That(editedPrice == "$" + price + ".00", "Price record has not been updated");
        }

        [When(@"I delete an existing record")]
        public void WhenIDeleteAnExistingRecord()
        {
            tMPageObj.DeleteTimeRecord(driver);
        }

        [Then(@"the record should not be similat to '([^']*)'")]
        public void ThenTheRecordShouldNotBeSimilatTo(string storedCode)
        {
            string deletedCode = tMPageObj.GetDeletedCode(driver);

            Assert.That(deletedCode != storedCode, "Record has not been delete");
        }

        [AfterScenario]

        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
