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
        // Create a reference for Chrome browser
            IWebDriver driver = new ChromeDriver(); 

            string ActualResult;
            string ExpectedResult = "Google";
        static void Main(string[] args)
        {
            Program p = new Program();
            //p.RunTest1(p);
            //p.RunTest2(p);
            p.RunTest3(p);
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

        // TEST 3
        public void RunTest3(Program p) {
            p.Initialize3();
            p.ExecuteTest3();
            p.CloseTest3();
        }

        [SetUp]
        public void Initialize3()
        {
            // Go to FaceBook Page
            driver.Navigate().GoToUrl("https://www.facebook.com");
        }
        [Test]
        public void ExecuteTest3()
        {
            IWebElement acceptCookiesButton = driver.FindElement(By.Id("u_0_h"));
            acceptCookiesButton.Click();
            
            IWebElement signupButton = driver.FindElement(By.Id("u_0_2"));
            signupButton.Click();

            Thread.Sleep(2000);
            
            IWebElement firstName = driver.FindElement(By.Id('u_y_b'));
            firstName.SendKeys("John");

            IWebElement lastName = driver.FindElement(By.Id("u_y_d"));
            lastName.SendKeys("Wick");

            IWebElement email = driver.FindElement(By.Id("u_y_g"));
            email.SendKeys("asdlfkj@gmail.com");

            IWebElement reEnterEmail = driver.FindElement(By.Id("u_y_j"));
            email.SendKeys("asdlfkj@gmail.com");

            IWebElement password = driver.FindElement(By.Id("password_step_input"));
            email.SendKeys("myawesomepassword");

            IWebElement month = driver.FindElement(By.Id("month"));
            var selectElementMonth = new SelectElement(month);
            selectElementMonth.SelectByValue("12");

            IWebElement day = driver.FindElement(By.Id("day"));
            var selectElementDay = new SelectElement(day);
            selectElementDay.SelectByValue("7");

            IWebElement year = driver.FindElement(By.Id("year"));
            var selectElementYear = new SelectElement(year);
            selectElementYear.SelectByValue("2005");

            IWebElement genderButton = driver.FindElement(By.Id("u_y_3"));
            genderButton.Click();

            IWebElement signUpButton2 = driver.FindElement(By.Id("u_y_s"));
            signUpButton2.Click();

            IWebElement errorMessage = driver.FindElement(By.XPath(""));
        }
        
        
        [TearDown]
        public void CloseTest3()
        {
            //Close the browser
            driver.Quit();
        }


    }
}
