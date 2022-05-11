using System;
using System.Threading;
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
        private static readonly string DriverDirectory = "C:\\Users\\syv22\\OneDrive\\Dokumenter\\1.Datamatiker_ting\\Web_drivers";

        private static readonly string url = "file:C:\\Users\\syv22\\OneDrive\\Dokumenter\\1.Datamatiker_ting\\3.SemesteV2\\EksamensprojektHtml\\RestExcusesHtml-master\\RestExcusesHtml\\index.html";


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

            _driver.Navigate().GoToUrl(url);
            IWebElement buttonElement1 = wait.Until(d => d.FindElement(By.Id("switchButton")));
            buttonElement1.Click();
            IWebElement indputElement = wait.Until(d => d.FindElement(By.Id("excuseInput")));
            indputElement.SendKeys("new test");
            IWebElement buttonElement = _driver.FindElement(By.Id("CreateButton"));
            buttonElement.Click();

            IWebElement excuseList = wait.Until(d => d.FindElement(By.Id("getAllExcuses")));
            Thread.Sleep(2000);
            string text = excuseList.Text;
            Assert.IsTrue(text.Contains("new test"));

        }
        [TestMethod]
        public void TestUpdate()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Navigate().GoToUrl(url);


            IWebElement buttonElement1 = wait.Until(d => d.FindElement(By.Id("switchButton")));
            buttonElement1.Click();

            IWebElement inputElement = _driver.FindElement(By.Id("updateIdInput"));
            inputElement.SendKeys("5");

            IWebElement excuseUpdate = _driver.FindElement(By.Id("updateExcuseInput"));
            excuseUpdate.SendKeys("UI Test-excuse");
            
            IWebElement buttonElement = _driver.FindElement(By.Id("UpdateButton"));
            buttonElement.Click();

            IWebElement excuseList = wait.Until(d => d.FindElement(By.Id("getAllExcuses")));
            Thread.Sleep(2000); //den er nødt til at vente på at excuses loader før den smider det i en string

            string text = excuseList.Text;
            
            Assert.IsTrue(text.Contains("UI Test-excuse"));
        }
        [TestMethod]
        public void TestDelete()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            _driver.Navigate().GoToUrl(url);
            IWebElement buttonElement1 = wait.Until(d => d.FindElement(By.Id("switchButton")));
            buttonElement1.Click();
            IWebElement indputElement = wait.Until(d => d.FindElement(By.Id("excuseInput")));
            indputElement.SendKeys("new test");
            IWebElement buttonElement = _driver.FindElement(By.Id("CreateButton"));
            buttonElement.Click();

            IWebElement excuseList = wait.Until(d => d.FindElement(By.Id("getAllExcuses")));
            Thread.Sleep(2000);
            string text = excuseList.Text;
            Assert.IsTrue(text.Contains("new test"));

            IWebElement deleteButton = wait.Until(d => d.FindElement(By.Id("1")));
            deleteButton.Click();

        }
    }
    
}
