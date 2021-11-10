using AutomatinisTestavimas.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas.Test
{
    class SeleniumCheckBoxTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://demo.seleniumeasy.com/basic-checkbox-demo.html";
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
        [OneTimeTearDown]
        public static void TearDovn()
        {
            _driver.Quit();
        }
        [Test]
        public void FirstBlockCheck()
        {
            SeleniumCheckBoxPage page = new SeleniumCheckBoxPage(_driver);
            page.MarkCheckBox();
            page.CheckTextResult("Success - Check box is checked");
        }
        [Test]
        public void SecondBlockFirstTask()
        {
            SeleniumCheckBoxPage page = new SeleniumCheckBoxPage(_driver);
            page.FirstCheckBoxClick();
            page.MultipleCheckboxClick();
            page.ButtonName("Uncheck All");
        }
        [Test]
        public void SecondBlockSecondTask()
        {
            SeleniumCheckBoxPage page = new SeleniumCheckBoxPage(_driver);
            page.FirstCheckBoxClick();
            page.MultipleCheckboxList();
        }
    }
}
