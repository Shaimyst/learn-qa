using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;

namespace selenium_automation
{
    class Program
    {
        // Create a reference for Chrome browser
            IWebDriver driver = new ChromeDriver(); 

            string ActualResult;
            string ExpectedResult = "Google";
        static void Main(string[] args)
        {
            Program p = new Program();
            //p.RunTest1(p);
            p.RunTest2(p);
        }

        // TEST 1
        public void RunTest1(Program p) {
            p.Initialize1();
            p.ExecuteTest1();
            p.CloseTest1();
        }

        [SetUp]
        public void Initialize1()
        {
            // Go to Google Page
            driver.Navigate().GoToUrl("https://www.google.com");
        }
        [Test]
        public void ExecuteTest1()
        {
            //Make the browser fullscreen
            driver.Manage().Window.Maximize();

            // Find the element
            IWebElement searchBox = driver.FindElement(By.Name("q"));

            //Type something in the search bar
            searchBox.SendKeys("google news");
        
            //Get the page title
            ActualResult = driver.Title;

            //Assert
            Assert.AreEqual(ActualResult, ExpectedResult);
            
            
            //Another way to assert, but this won't tell you what went wrong. 
            //Assert.That(Equals(ActualResult, ExpectedResult));
        }
        
        
        [TearDown]
        public void CloseTest1()
        {
            //Close the browser
            driver.Quit();
        }


        // TEST 2
        public void RunTest2(Program p) {
            p.Initialize2();
            p.ExecuteTest2();
            p.CloseTest2();
        }

        [SetUp]
        public void Initialize2()
        {
            // Go to Amazon Page
            driver.Navigate().GoToUrl("https://www.amazon.se");
        }
        [Test]
        public void ExecuteTest2()
        {
            //Make the browser fullscreen
            driver.Manage().Window.Maximize();

            // Find the sign in button
            IWebElement signIn = driver.FindElement(By.Id("nav-link-accountList"));
            signIn.Click();

            IWebElement emailField = driver.FindElement(By.Id("ap_email"));
            emailField.SendKeys("hi@email.com");

            IWebElement continueButton = driver.FindElement(By.Id("continue"));
            continueButton.Click();

            IWebElement errorMessage = driver.FindElement(By.ClassName("a-alert-heading"));
            string actualErrorMessageText = errorMessage.Text;
            string expectedErrorMessageText = "There was a problem";
            Assert.AreEqual(actualErrorMessageText, expectedErrorMessageText);

        
        }
        
        
        [TearDown]
        public void CloseTest2()
        {
            //Close the browser
            driver.Quit();
        }
    }
}
