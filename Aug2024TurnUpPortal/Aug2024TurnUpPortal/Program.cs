using Aug2024TurnUpPortal.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

public class Program
{
    private static void Main(string[] args)
    {
        //open Chrome Browser
        IWebDriver driver = new ChromeDriver();

        //Login page object initialization and definition
        LoginPage loginPageObj = new LoginPage();

        loginPageObj.LoginActions(driver);

        //Home page object initialization and definition
        HomePage homePageObj = new HomePage();

        homePageObj.NavigateTOTMPage(driver);

        //TMPage page object initialization and definition
        TMPage tMPageObj = new TMPage();

        tMPageObj.CreateTimeRecord(driver);
        //Edit Time record
        tMPageObj.EditTimeRocord(driver);

        //Delete Time record
        tMPageObj.DeleteTimeRecord(driver);

    }
}