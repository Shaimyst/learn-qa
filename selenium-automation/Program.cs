using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;

namespace selenium_automation
{
    class Program
    {

        // create a reference for chrome browser
        IWebDriver driver = new ChromeDriver();
        
        string actualResult;
        string expectedResult = "Google";

        static void Main(string[] args)
        {
            Program p = new Program();
            // p.RunTest1(p);
            p.RunTest2(p);
        }

        
        // TEST 1
        public void RunTest1(Program p) {
            p.Initialize1();
            p.ExecuteTest1();
            p.CloseTest1();
        }

        [SetUp]
        public void Initialize1() {
            // go to google page
            driver.Navigate().GoToUrl("https://www.google.com");
        }

        [Test]
        public void ExecuteTest1() {
            // make the browser window full screen
            driver.Manage().Window.Maximize();
            // find the element
            IWebElement searchBox = driver.FindElement(By.Name("q"));
            // type something in the search bar
            searchBox.SendKeys("cats");
            // get the page title
            actualResult = driver.Title;
            // make assertion
            Assert.AreEqual(actualResult, expectedResult);
            // alternative way to make assertion (doesn't print actual and expected)
            // Assert.That(Equals(ActualResult, ExpectedResult));
        }

        [TearDown]
        public void CloseTest1() {
            // close the browser
            driver.Quit();
        }


        // TEST 2
        public void RunTest2(Program p) {
            p.Initialize2();
            p.ExecuteTest2();
            p.CloseTest2();
        }

        [SetUp]
        public void Initialize2() {
            // go to amazon page
            driver.Navigate().GoToUrl("https://www.amazon.se");
        }

        [Test]
        public void ExecuteTest2() {
            // find the sign-in button
            IWebElement signIn = driver.FindElement(By.Id("nav-link-accountList"));
            // operations
            signIn.Click();
            // find the email input element
            IWebElement emailField = driver.FindElement(By.Id("ap_email"));
            // type mock email to email input
            emailField.SendKeys("pewpew@something.com");
            // find continue button
            IWebElement continueButton = driver.FindElement(By.Id("continue"));
            // click continue button
            continueButton.Click();
            // find error message
            IWebElement errorMessage = driver.FindElement(By.ClassName("a-alert-heading"));
            // get the text string from the error message
            string actualErrorMessage = errorMessage.Text;
            string expectedErrorMessage = "Ett problem uppstod";
            // make test assertion
            Assert.AreEqual(actualErrorMessage, expectedErrorMessage);
        }

        [TearDown]
        public void CloseTest2() {
            // close the browser
            driver.Quit();
        }

    }
}
