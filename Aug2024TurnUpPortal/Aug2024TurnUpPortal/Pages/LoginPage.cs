using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aug2024TurnUpPortal.Pages
{
    public class LoginPage
    {
        private readonly By userNameTextboxLocator = By.Id("UserName");
        IWebElement usernameTextbox;

        public void LoginActions(IWebDriver driver)
        {
        //Lunch TurnUp portal
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
        driver.Manage().Window.Maximize();
        Thread.Sleep(3000);

            //Implicit wait
            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //Explicit wait
            //WebDriverWait wait = new WebDriverWait(driver, Timespan(5));
            //wait.Untill(SeleniumExtras.WaitHelpers.ExpectedConditions.ElemeyIsVisible(By.Id("UserName"));

            
            try
            {
                //Identify user name textbox and enter valid user name
                usernameTextbox = driver.FindElement(userNameTextboxLocator);
                usernameTextbox.SendKeys("hari");
            }
            catch (Exception ex)
            {
                Assert.Fail("Username textbox not located");
            }

        //Identify password textbox and enter valid password
        IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
        passwordTextbox.SendKeys("123123");

        //Identify login button and click on it
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButton.Click();
        Thread.Sleep(3000);
        }

    }
}
