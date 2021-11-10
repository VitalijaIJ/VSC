using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas.Test
{
    public class VartuTechnikaTest
    {
        private static ChromeDriver _driver;

        private static IWebDriver();

        [OneTimeSetUp]

        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://vartutechnika.lt/");
            WebDriverWait = new WebDriver(_driver, TimeSpan.FromSeconds(10));
            _driver.Manage().Window.Maximize();
            _driver.FindElement(By.Id("cookiescript_reject")).Click();
        }
        [OneTimeTearDown]
        public static void TearDown()
        {
            //_driver.Quit();
        }
        [TestCase("2000", "2000", true, false, "665.98€", TestName = "2000 x 2000 + Vartų automatika = 665.98€")]
        [TestCase("4000", "2000", true, true, "1006.43€", TestName = "4000 + 2000 + Vartu automatika + Vartu montavimo darbai = 1006.43€")]
        [TestCase("4000", "2000", false, false, "692.35€", TestName = "4000 + 2000 = 692.35€")]
        public void TestVartuTechnika(string width, string height, bool automatika, bool montavimoDarbai, string result)
        {
            VartuTechnikaPage page = new VartuTechnikaPage(_driver);
            page.InsertWidthAndHeight(width, height);
            page.CheckAutomatikCheckBox(automatika);
            page.CheckMondavimoDarbaiCheckBox(montavimoDarbai);
            page.ClickCalculateButton();
            page.CheckResult(result);
        }
    }
}
