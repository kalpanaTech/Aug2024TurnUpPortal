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
    public class LoginPage
    {
        private readonly By userNameTextboxLocator = By.Id("UserName");
        IWebElement usernameTextbox;

        private readonly By passwordTextboxLocator = By.Id("Password");
        IWebElement passwordTextbox;

        private readonly By loginButtonLocator = By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]");
        IWebElement loginButton;

        public void LoginActions(IWebDriver driver)
        {
            //Lunch TurnUp portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
            driver.Manage().Window.Maximize();
            // Thread.Sleep(4000);
            Wait.WaitToBeClickable(driver, "Id", "UserName", 4);

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

            try
            {
                //Identify password textbox and enter valid password
                passwordTextbox = driver.FindElement(passwordTextboxLocator);
                passwordTextbox.SendKeys("123123");
            }
            catch (Exception ex)
            {
                Assert.Fail("Password textbox not located");
            }

            try
            {
                //Identify login button and click on it
                loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
                loginButton.Click();
                Thread.Sleep(8000);
            }
            catch (Exception ex)
            {
                Assert.Fail("Login button not located");
            }
        }

    }
}
