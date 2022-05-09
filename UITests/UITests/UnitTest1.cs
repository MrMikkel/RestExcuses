using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace UITests
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\Users\\syv22\\OneDrive\\Dokumenter\\Datamatiker ting\\Web_drivers";

        private static readonly string url = "file:C:\\Users\\syv22\\OneDrive\\Dokumenter\\Datamatiker ting\\Eksamens projekt\\Html\\RestExcusesHtml\\index.html";


        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory); // fast
            //_driver = new FirefoxDriver(DriverDirectory);  // slow
            //_driver = new EdgeDriver(DriverDirectory); // now working

        }
        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestGetAllExcuses()
        {
            //WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            ////string url = "file:C:\\Users\\syv22\\OneDrive\\Dokumenter\\1.Datamatiker_ting\\3.SemesteV2\\EksamensprojektHtml\\RestExcusesHtml-master\\index.html";

            //_driver.Navigate().GoToUrl(url);

            //IWebElement buttonElement = _driver.FindElement(By.Id("getButton"));
            //buttonElement.Click();
            ////Thread.Sleep(2000);
            ////IWebElement excuseList = _driver.FindElement(By.Id("getAllExcuses"));
            
            //IWebElement excuseList = wait.Until(d => d.FindElement(By.Id("getAllExcuses")));
            //string text = excuseList.Text;
            //Assert.IsTrue(text.Contains("3"));

        }
        [TestMethod]
        public void TestPost()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            ////string url = "file:C:\\Users\\syv22\\OneDrive\\Dokumenter\\1.Datamatiker_ting\\3.SemesteV2\\EksamensprojektHtml\\RestExcusesHtml-master\\index.html";

            _driver.Navigate().GoToUrl(url);

            IWebElement indputElement = _driver.FindElement(By.Id("excuseInput"));
            indputElement.SendKeys("new excuse");
            IWebElement buttonElement = _driver.FindElement(By.Id("CreateButton"));
            buttonElement.Click();

            IWebElement excuseList = wait.Until(d => d.FindElement(By.Id("getAllExcuses")));
            string text = excuseList.Text;
            Assert.IsTrue(text.Contains("new excuse"));

        }
    }
}
