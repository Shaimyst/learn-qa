using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System;
using System.Threading;

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
            // p.RunTest2(p);
            // p.RunTest3(p);
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


        // TEST 3
        public void RunTest3(Program p) {
            p.Initialize3();
            p.ExecuteTest3();
            p.CloseTest3();
        }

        [SetUp]
        public void Initialize3() {
            driver.Navigate().GoToUrl("https://facebook.com");
        }

        [Test]
        public void ExecuteTest3() {

            IWebElement acceptCookiesButton = driver.FindElement(By.Id("u_0_k"));
            acceptCookiesButton.Click();

            IWebElement signupButton = driver.FindElement(By.Id("u_0_2"));
            signupButton.Click();

            Thread.Sleep(2000);

            IWebElement firstName = driver.FindElement(By.Id("u_2_b"));
            firstName.SendKeys("John");
            
            IWebElement lastName = driver.FindElement(By.Id("u_2_d"));
            lastName.SendKeys("Wick");
            
            IWebElement email = driver.FindElement(By.Id("u_2_g"));
            email.SendKeys("alksdjflasdjf@gmail.com");

            IWebElement reEnterEmail = driver.FindElement(By.Id("u_2_j"));
            reEnterEmail.SendKeys("alksdjflasdjf@gmail.com");

            IWebElement password = driver.FindElement(By.Id("password_step_input"));
            password.SendKeys("myawesomepassword");

            IWebElement month = driver.FindElement(By.Id("month"));
            SelectElement selectElementMonth = new SelectElement(month);
            selectElementMonth.SelectByValue("12");

            IWebElement day = driver.FindElement(By.Id("day"));
            SelectElement selectElementDay = new SelectElement(day);
            selectElementDay.SelectByValue("7");

            IWebElement year = driver.FindElement(By.Id("year"));
            SelectElement selectElementYear = new SelectElement(year);
            selectElementYear.SelectByValue("2005");

            IWebElement genderInput = driver.FindElement(By.Id("u_2_3"));
            genderInput.Click();
            
            IWebElement signupButton2 = driver.FindElement(By.Id("u_2_s"));
            signupButton2.Click();
            
            IWebElement resultHeader = driver.FindElement(By.ClassName("uiHeaderTitle"));
            string expectedHeader = "Enter the code from your email";
            
            Thread.Sleep(5000);

            // make test assertion
            Assert.AreEqual(resultHeader.Text, expectedHeader);
        }

        [TearDown]
        public void CloseTest3() {
            // close the browser
            driver.Quit();
        }


    }
}
