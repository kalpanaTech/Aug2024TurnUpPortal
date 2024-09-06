using Aug2024TurnUpPortal.Pages;
using Aug2024TurnUpPortal.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aug2024TurnUpPortal.Tests
{
    //[Parallelizable]
    [TestFixture]
    public class TM_Tests : CommonDriver
    {
        [SetUp]
        public void SetUpStatus()
        {
            //open Chrome Browser
            driver = new ChromeDriver();

            //Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);


            //Home page object initialization and definition : Navigate TO TM Page
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateTOTMPage(driver);
        }

        [Test, Order(1), Description("This test will verified Time & Material Record creation")]
        public void CreateTime_Test()
        {
            //Create Time Record
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTimeRecord(driver, "", "", "", "");
        }

        [Test, Order(2), Description("This test will verified Time & Material Record update")]
        public void EditTime_Test()
        {
            //Edit Time record
            TMPage tMPageObj = new TMPage();
            tMPageObj.EditTimeRocord(driver, "", "", "", "");
        }

        [Test, Order(3), Description("This test will verified Time & Material Record delete")]
        public void DeleteTime_Test()
        {
            //Delete record
            TMPage tMPageObj = new TMPage();
            tMPageObj.DeleteTimeRecord(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
 