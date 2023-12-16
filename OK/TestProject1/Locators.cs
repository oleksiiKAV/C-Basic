using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1
{
    public class Locators
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
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            /*new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize(); // maximize window size*/
        }

        [Test]
        public void usernameSend()
        {
            TestContext.Progress.WriteLine("Test1");
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Name("password")).SendKeys("123456");
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            driver.FindElement(By.CssSelector("input[value = 'Sign In']")).Click();
            //driver.FindElement(By.XPath("//input[@value = 'Sign In']")).Click();

            // Thread.Sleep(3000); - don't recomended
            // explicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers
                .ExpectedConditions
                .TextToBePresentInElementValue(driver.FindElement(By.Id("signInBtn")), "Sign In"));
            // explicit wait
            String errMess = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine($"Title is: {driver.Title}");
            
            TestContext.Progress.WriteLine($"Err mess is: {errMess}");

            IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            String linkAttr = link.GetAttribute("href");
            String expectedAttr = "https://rahulshettyacademy.com/documents-request";

            // Assert.AreEqual(expectedAttr, actual: linkAttr);
            Assert.That(linkAttr, Is.EqualTo(expectedAttr));
        }

        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("Test2");
            Assert.Pass();
        }

        [TearDown]
        public void CloseBrowser()
        {
            TestContext.Progress.WriteLine("Testing post-condition");
            driver.Close(); // Close current open window
            // driver.Quit(); - close All tests window
        }
    }
}
