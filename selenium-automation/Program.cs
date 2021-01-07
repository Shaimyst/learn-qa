using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace selenium_automation
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a reference for chrome browser
            IWebDriver driver = new ChromeDriver();
            // go to google page
            driver.Navigate().GoToUrl("https://www.google.com");
            // make the browser window full screen
            driver.Manage().Window.Maximize();
            // find the element
            IWebElement searchBox = driver.FindElement(By.Name("q"));
            // type something in the search bar
            searchBox.SendKeys("cats");
            // close the browser
            driver.Quit();
        }
    }
}
