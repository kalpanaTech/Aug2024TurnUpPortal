using Aug2024TurnUpPortal.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aug2024TurnUpPortal.Pages
{
    public class EmployeePage
    {
        public void CreateEmployeeRecord(IWebDriver driver)
        {

            try
            {
                // Click on Create Button
                IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
                createNewButton.Click();
            }
            catch (NoSuchElementException ex)
            {
                Assert.Fail(ex.Message);
            }

            //Enter Name
            IWebElement nameTextbox = driver.FindElement(By.Id("Name"));
            nameTextbox.SendKeys("Amelia");

            //Enter User Name
            IWebElement userNameTextbox = driver.FindElement(By.Id("Username"));
            userNameTextbox.SendKeys("Clarke");

            //Enter Contact
            IWebElement contactBox = driver.FindElement(By.XPath("//*[@id=\"ContactDisplay\"]"));
            contactBox.SendKeys("2345654343");

            //Enter Password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("234abc");

            //Retype password
            IWebElement retypePasswordTextbox = driver.FindElement(By.Id("RetypePassword"));
            retypePasswordTextbox.SendKeys("234abc");

            //check the check box is admin
            IWebElement adminCheckBox = driver.FindElement(By.Id("IsAdmin"));
            adminCheckBox.Click();

            //Enter vehicle ID details
            IWebElement vehicleIdInputBox = driver.FindElement(By.XPath("//*[@id=\"UserEditForm\"]/div/div[7]/div/span[1]/span/input"));
            vehicleIdInputBox.SendKeys("GGK123");

            //Enter groups
            IWebElement groupsFeild = driver.FindElement(By.XPath("//*[@id=\"UserEditForm\"]/div/div[8]/div/div/div[1]"));
            groupsFeild.Click();
            Thread.Sleep(2000);

            IWebElement groupName = driver.FindElement(By.XPath("//*[@id=\"groupList_listbox\"]/li[1]"));
            groupName.Click();

            //Save
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(5000);

            //Back to the List
            IWebElement backToListOption = driver.FindElement(By.XPath("//*[@id=\"container\"]/div/a"));
            backToListOption.Click();
            Thread.Sleep(10000);
            //Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 5);
            //Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 5);

            try
            {
                // Check if Employee record has been created successfully
                IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
                goToLastPageButton.Click();
            }
            catch (NoSuchElementException ex)
            {
                Assert.Fail(ex.Message);
            }
            
            //Verify the added record
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(newCode.Text == "Amelia", "Employee record has not been created");
        }

        public void EditEmployeeRecord(IWebDriver driver)

        {
            Thread.Sleep(4000);
            try
            {
                //Click on the last page button
                IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
                goToLastPageButton.Click();


            }
            catch (NoSuchElementException ex)
            {
                Assert.Fail(ex.Message);
            }

            Thread.Sleep(2000);
            IWebElement empEditButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[1]"));
            empEditButton.Click();

            //Edit Name
            IWebElement nameTextbox = driver.FindElement(By.Id("Name"));
            nameTextbox.Clear();
            nameTextbox.SendKeys("Ivon");

            //Edit User Name
            IWebElement userNameTextbox = driver.FindElement(By.Id("Username"));
            userNameTextbox.Clear();
            userNameTextbox.SendKeys("Smith");

            //Edit Contact
            IWebElement contactBox = driver.FindElement(By.XPath("//*[@id=\"ContactDisplay\"]"));
            contactBox.SendKeys("2345654343");

            //Edit Password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("234abc");

            //Retype password
            IWebElement retypePasswordTextbox = driver.FindElement(By.Id("RetypePassword"));
            retypePasswordTextbox.SendKeys("234abc");

            //Uncheck the check box is admin
            IWebElement adminCheckBox = driver.FindElement(By.Id("IsAdmin"));
            adminCheckBox.Click();

            //Edit vehicle ID details
            IWebElement vehicleIdInputBox = driver.FindElement(By.XPath("//*[@id=\"UserEditForm\"]/div/div[7]/div/span[1]/span/input"));
            vehicleIdInputBox.SendKeys("GGK123");

            //Edit groups
            IWebElement addedGroup1 = driver.FindElement(By.XPath("//*[@id=\"groupList_taglist\"]/li/span[2]"));
            addedGroup1.Click();

            IWebElement groupsFeild = driver.FindElement(By.XPath("//*[@id=\"UserEditForm\"]/div/div[8]/div/div/div[1]"));
            groupsFeild.Click();

            IWebElement groupName = driver.FindElement(By.XPath("//*[@id=\"groupList_listbox\"]/li[8]"));
            groupName.Click();

            //Save
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(5000);

            //Back to the List
            IWebElement backToListOption = driver.FindElement(By.XPath("//*[@id=\"container\"]/div/a"));
            backToListOption.Click();
            Thread.Sleep(10000);

            try
            {
                // Check if Employee record has been updated successfully
                IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
                goToLastPageButton.Click();

            }
            catch (NoSuchElementException ex)
            {
                Assert.Fail(ex.Message);
            }
            Thread.Sleep(2000);
            //Verify the updated record
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(newCode.Text == "Ivon", "Employee record has not been updated");
        }



        public void DeleteEmployeeRecord(IWebDriver driver)

        {

            Thread.Sleep(4000);
            try
            {
                //Click on the last page button
                IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
                goToLastPageButton.Click();


            }
            catch (NoSuchElementException ex)
            {
                Assert.Fail(ex.Message);
            }

            Thread.Sleep(2000);

            //Click on the last record delete button
            IWebElement empDeleteButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[2]"));
            empDeleteButton.Click();

            //Click on the pop up window
            IAlert simpleAlert = driver.SwitchTo().Alert();
            String alertText = simpleAlert.Text;
            Console.WriteLine("Alert text is, Are you sure you want to delete this record? " + alertText);
            simpleAlert.Accept();

            try
            {
                //Click on the last page button
                IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
                goToLastPageButton.Click();


            }
            catch (NoSuchElementException ex)
            {
                Assert.Fail(ex.Message);
            }

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (newCode.Text == "Ivon")
            {
                Console.WriteLine("Record deletion unsuccessfull");
            }
            else
            {
                Console.WriteLine("Record deletion successfull");
            }

        }
    }
}

