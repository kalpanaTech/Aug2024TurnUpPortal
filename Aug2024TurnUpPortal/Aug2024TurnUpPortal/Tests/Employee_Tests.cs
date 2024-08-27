using Aug2024TurnUpPortal.Pages;
using Aug2024TurnUpPortal.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aug2024TurnUpPortal.Tests
{
    //[Parallelizable]
    [TestFixture]
    public class Employee_Tests : CommonDriver
    {
        [SetUp]
        public void SetUpStatus()
        {
            //open Chrome Browser
            driver = new ChromeDriver();

            //Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);


            //Home page object initialization and definition : Navigate To EMPPage
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToEMPPage(driver);
        }

        [Test, Order(1), Description("This test will verified Employee Record creation")]
        public void CreateEmployee_Test()
        {
            //Create Employee record
            EmployeePage empPageObj = new EmployeePage();
            empPageObj.CreateEmployeeRecord(driver);
        }

        [Test, Order(2), Description("This test will verified Employee Record update")]
        public void EditEmployee_Test()
        {
            //Edit Employee record
            EmployeePage empPageObj = new EmployeePage();
            empPageObj.EditEmployeeRecord(driver);
        }

        [Test, Order(3), Description("This test will verified Employee Record delete")]
        public void DeleteEmployee_Test()
        {
            //Delete Employee record
            EmployeePage empPageObj = new EmployeePage();
            empPageObj.DeleteEmployeeRecord(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
