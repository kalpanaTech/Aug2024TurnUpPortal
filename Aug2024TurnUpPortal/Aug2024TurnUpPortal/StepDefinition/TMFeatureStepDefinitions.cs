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
        [Given(@"I logged into TurnUp portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
            //open Chrome Browser
            driver = new ChromeDriver();

            //Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

        }

        [When(@"I navigate to Time and Material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            //Home page object initialization and definition : Navigate TO TM Page
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateTOTMPage(driver);
        }

        [When(@"I create a time record")]
        public void WhenICreateATimeRecord()
        {
            //Create Time Record
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTimeRecord(driver);
        }

        [Then(@"the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            //create object from TMPage class
            TMPage tMPageObj = new TMPage();

            //call the 'GetCode()' mothod using the object 'tMPageObj' and assign the returned value to 'string newCode'
            string newCode = tMPageObj.GetCode(driver);
            string newDescription =  tMPageObj.GetDescription(driver);
            string newPrice = tMPageObj.GetPrice(driver);
          
            //verify the stored value to 'newCode' 
            Assert.That(newCode == "TA Programme KLD", "Actual Code and expected Coce do not match.");
            Assert.That(newDescription == "This is a description", "Actual Description and expected Description do not match.");
            Assert.That(newPrice == "$22.00", "Actual Price and expected Price do not match.");
        
        }

        [When(@"I update the '([^']*)' on an existing Time record")]
        public void WhenIUpdateTheOnAnExistingTimeRecord(string code)
        {
            
            TMPage tMPageObj = new TMPage();
            tMPageObj.EditTimeRocord(driver, code);
        }

        [Then(@"the record should have the updated '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdated(string code)
        {
            //create object from TMPage class
            TMPage tMPageObj = new TMPage();

            //call the 'GetCode()' mothod using the object 'tMPageObj' and assign the returned value to 'string newCode'
            string editCode = tMPageObj.GetEditedCode(driver);

            Assert.That(editCode == code, "Time record has not been updated");
        }
    }
}
