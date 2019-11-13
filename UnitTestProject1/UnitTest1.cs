using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace SeleniumBrowserTests
{
    /// <summary>
    /// Summary description for MySeleniumTests
    /// </summary>
    [TestClass]
    public class MySeleniumTests
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        public MySeleniumTests()
        {
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void PikselWebAppTest()
        {
            driver.Navigate().GoToUrl(appURL + "/");
            IWebElement searchLink = driver.FindElement(By.Id("auto01"));
            searchLink.Click();

            //     driver.FindElement(By.Id("sb_form_q")).SendKeys("Azure Pipelines");
            //   driver.FindElement(By.Id("sb_form_go")).Click();
            //  IWebElement bodyTag = driver.findElement(By.tagName("body"));
            IWebElement body = driver.FindElement(By.TagName("body"));

            Assert.IsTrue(body.Text.Contains("Get started with ASP.NET Core MVC"));
            //
                        //driver.FindElement(By.XPath("//ol[@id='b_results']/li/h2/a/strong[3]")).Click();
                        //Assert.IsTrue(driver.Title.Contains("Azure"), "Verified title of the page");
                        //Assert.IsTrue("h2[contains(text(), 'Azure')]", "Verified");
           //     Console.WriteLine(driver.Title);
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value; 
            }
        }

        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "https://pulterraformweb94bbd0cc.azurewebsites.net";

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
           driver.Quit();
        }
    }
}