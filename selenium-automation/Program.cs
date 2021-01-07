using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace selenium_automation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a reference for Chrome browser
            IWebDriver driver = new ChromeDriver(); 

            // Go to Google Page
            driver.Navigate().GoToUrl("https://www.google.com");

            //Make the browser fullscreen
            driver.Manage().Window.Maximize();

            // Find the element
            IWebElement searchBox = driver.FindElement(By.Name("q"));

            //Type something in the search bar
            searchBox.SendKeys("google news");

            //Close the browser
            driver.Quit();
        }
    }
}
