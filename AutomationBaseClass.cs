using System;
using CareXm.Selenium.Project.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium.CareXm.Project
{
    [TestFixture]
    public class AutomationBaseClass
    {
        public IWebDriver driver;

        //[SetUp]
        public IWebDriver  OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Config.url);
            driver.Manage().Window.Maximize();
            return driver;
        }




        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
            driver.Quit();
        }


    }
}
