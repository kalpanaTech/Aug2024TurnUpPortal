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
        public void CreateTimeRecord(IWebDriver driver, string typeCode, string code, string description, string price)
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
            Thread.Sleep(2000);

            if (typeCode == "T")
            {
                IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
                timeOption.Click();
                Thread.Sleep(2000);
            }

            else if (typeCode == "M")
            {
                IWebElement materialOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[1]"));
                materialOption.Click();
                Thread.Sleep(2000);
            }

            // Type code into Code textbox
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys(code);

            // Type Description into Description textbox
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys(description);

            // Type price into Price textbox
            IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTagOverlap.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys(price);

            Wait.WaitToBeClickable(driver, "Id", "SaveButton", 3);

            // Click on Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(10000);

            // Check if Time record has been created successfully
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            Thread.Sleep(6000);
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 10);
            goToLastPageButton.Click();
            Thread.Sleep(7000);
        }

        public void EditTimeRocord(IWebDriver driver, string typeCode, string code, string description, string price)
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
            Thread.Sleep(8000);
            editButton.Click();

            //Change the TypeCode
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            if (typeCode == "T")
            {
                IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
                timeOption.Click();
                Thread.Sleep(2000);
            }

            else if (typeCode == "M")
            {
                IWebElement materialOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[1]"));
                materialOption.Click();
                Thread.Sleep(2000);
            }
            else
            {
                IWebElement selectedOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_option_selected\"]"));
                selectedOption.Click();
                Thread.Sleep(2000);
            }

            // Change the Code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.Clear();
            codeTextbox.SendKeys(code);
            Thread.Sleep(2000);


            // Chage the Description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.Clear();
            descriptionTextbox.SendKeys(description);

            // Change the Price per unit
            IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTagOverlap.Click();


            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.Clear();
            Thread.Sleep(2000);

            priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTagOverlap.Click();
            priceTextbox = driver.FindElement(By.Id("Price"));
            Thread.Sleep(2000);
            priceTextbox.Click();
            priceTextbox.SendKeys(price);

            // Save the changes
            // Click on Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(4000);
            
            // Check if Time record has been created successfully
            goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            Thread.Sleep(6000);
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 10);
            goToLastPageButton.Click();
            Thread.Sleep(10000);

        }

        public string GetEditedTypeCode(IWebDriver driver)
        {
           // Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[2]", 10);
            IWebElement editedTypeCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));
            return editedTypeCode.Text;
        }
        public string GetEditedCode(IWebDriver driver)
        {
            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return editedCode.Text;
        }

        public string GetEditedDescription(IWebDriver driver)
        {
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return editedDescription.Text;
        }
        public string GetEditedPrice(IWebDriver driver)
        {
            IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return editedPrice.Text;
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
            Thread.Sleep(7000);


            // Click on the Delete Button
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();

            Thread.Sleep(4000);

            //Click OK to delete 
            driver.SwitchTo().Alert().Accept();

            Thread.Sleep(3000);

            driver.Navigate().Refresh();

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
            
            Thread.Sleep(7000);
        }

        public string GetDeletedCode(IWebDriver driver)
        {
            IWebElement deletedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Thread.Sleep(7000);
            return deletedCode.Text;
        }
    }
}
