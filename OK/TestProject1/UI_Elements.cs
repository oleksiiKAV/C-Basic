using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;

namespace TestProject1
{
    public class UI_Elements
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("Testing pre-condition");
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize(); // maximize window size
            // Implicit wailt 5 seconds can be set globally
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("Test1 GET DropDown");
            IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));
            SelectElement s = new SelectElement(dropdown);
            s.SelectByText("Teacher");
            // s.SelectByValue("consult"); // by value attr
            // s.SelectByIndex(0); // by index from dropdown array

            TestContext.Progress.WriteLine($"Title is: {driver.Title}");
            TestContext.Progress.WriteLine($"Url is: {driver.Url}");

        }

        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("Test2 GET and SET RadioButton");
            IList <IWebElement> radioBtn = driver.FindElements(By.CssSelector("input[type='radio']"));
            // radioBtn[1].Click(); // click on the 2-nd or use nect
            foreach (IWebElement radioButton in radioBtn)
            {
                if (radioButton.GetAttribute("value").Equals("user")) {
                    radioButton.Click();
                    break;
                }
            }
            // wait for pop-up with OK button
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));

            driver.FindElement(By.Id("okayBtn")).Click();
            Boolean result = driver.FindElement(By.Id("usertype")).Selected;
            
            Assert.That(result, Is.False); //False - specifically for this site implimentation

        }

        [TearDown]
        public void CloseBrowser()
        {
            TestContext.Progress.WriteLine("Testing post-condition");
           // driver.Close(); // Close current open window
            // driver.Quit(); - close All tests window
        }
    }
}
