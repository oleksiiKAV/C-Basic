using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("Testing pre-condition");
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize(); // maximize window size
            /*new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize(); // maximize window size*/
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("Test1");
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            TestContext.Progress.WriteLine($"Title is: {driver.Title}");
            TestContext.Progress.WriteLine($"Url is: {driver.Url}");
            
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