using Aug2024TurnUpPortal.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aug2024TurnUpPortal.Pages
{
    public class TMPage
    {
        public void CreateTimeRecord(IWebDriver driver)
        {
            
            try
            {
                // Click on Create New Button
                IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
                createNewButton.Click();
            }
            catch (NoSuchElementException ex)
            {
                Assert.Fail(ex.Message);
            }

            // Select Time from dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();

            // Type code into Code textbox
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("TA Programme KLD");

            // Type Description into Description textbox
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("This is a description");

            // Type price into Price textbox
            IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTagOverlap.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("22");

            Wait.WaitToBeClickable(driver, "Id", "SaveButton", 3);

            // Click on Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(8000);
            //Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 10);
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 10);

            try 
            {
                // Check if Time record has been created successfully
                IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
                Thread.Sleep(4000);
                //Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 10);
                goToLastPageButton.Click();
            }
            catch (NoSuchElementException ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        public string GetCode(IWebDriver driver)
        {
            //Storing the Code value to newCode as a text
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return newCode.Text;
            
        }

        public string GetDescription(IWebDriver driver)
        {
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return newDescription.Text;
        }

        public string GetPrice(IWebDriver driver)
        {
            IWebElement newPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return newPrice.Text;
        }


        public void EditTimeRocord(IWebDriver driver, string code)
        {
            IWebElement goToLastPageButton;

            Thread.Sleep(4000);
            try
            {
                // Edit the last created record
                goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
                Thread.Sleep(6000);
                goToLastPageButton.Click();
            }
            catch (NoSuchElementException ex)
            {
                Assert.Fail(ex.Message);
            }

            Thread.Sleep(4000);

            //Click on the Edit button
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            Thread.Sleep(4000);
            editButton.Click();
            

            // Change the Code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.Clear();
            codeTextbox.SendKeys(code);
            Thread.Sleep(2000);


            // Chage the Description
            //IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            //descriptionTextbox.Clear();
            //descriptionTextbox.SendKeys("This is an updated description");

            // Change the Price per unit
            //IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            //priceTagOverlap.Click();


            //IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            //priceTextbox.Clear();
            //priceTextbox.SendKeys("0");

            // Save the changes
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(4000);

            // Check if Time record has been created successfully
            //Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 10);
              
            goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            Thread.Sleep(6000);
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 10);
            goToLastPageButton.Click();
            Thread.Sleep(6000);
        }

        public string GetEditedCode(IWebDriver driver)
        {
            IWebElement editCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return editCode.Text;

        }
           
            public void DeleteTimeRecord(IWebDriver driver)
            {
            Thread.Sleep(4000);
            try
            {
                // Delete the last created record
                IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
                Thread.Sleep(4000);
                goToLastPageButton.Click();
            }
            catch (NoSuchElementException ex)
            {
                Assert.Fail(ex.Message);
            }

         

            // Click on the Delete Button
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            
            //Click OK to pop up window

            IAlert simpleAlert = driver.SwitchTo().Alert();
            String alertText = simpleAlert.Text;
            Console.WriteLine("Alert text is, Are you sure you want to delete this record? " + alertText);
            simpleAlert.Accept();

            try
            {
                // Check if Time record has been created successfully
                IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
                Thread.Sleep(4000);

                goToLastPageButton.Click();
            }
            catch (NoSuchElementException ex)
            {
                Assert.Fail(ex.Message);
            }

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (newCode.Text == "TA Programme Sep")
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
