using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AutomatinisTestavimas
{
    class Class2
    {
        // Puslapiui https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent parašyti testus, ar teisingai
        // parodo jūsų naršyklę, jei paleidžiate testus su:
        // chrome, firefox, opera ar safari(optional).

        private static IWebDriver _driver;
        private static string _textToCheck;
        [TestCase("Chrome", "Chrome", TestName = "Chrome test")]
        [TestCase("Firefox", "Firefox", TestName = "Firefox test")]
        public static void TestBrowsers(string browser, string visibleText)
        {
            switch (browser)
            {
                case "Chrome":
                    _driver = new ChromeDriver();
                    _textToCheck = visibleText;
                    break;
                case "Firefox":
                    _driver = new FirefoxDriver();
                    _textToCheck = visibleText;
                    break;
            }
            SetUp();
            string textOnPage = _driver.FindElement(By.CssSelector("#primary-detection > div")).Text;
            Assert.IsTrue(textOnPage.Contains(_textToCheck), "Text is not the same");
            TearDown();
        }
        private static void SetUp()
        {
            _driver.Navigate().GoToUrl("https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
        }
        private static void TearDown()
        {
          //  _driver.Quit();
        }

    }
    
}
