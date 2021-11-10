using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas.Page
{
    public class VartuTechnikaPage
    {
        private static IWebDriver _driver;
        private IWebElement _widthInput => _driver.FindElement(By.Id("doors_width"));
        private IWebElement _heightInput => _driver.FindElement(By.Id("doors_height"));
        private IWebElement _autoCheckBox => _driver.FindElement(By.Id("automatika"));
        private IWebElement _MontavimoCheckBox => _driver.FindElement(By.Id("darbai"));
        private IWebElement _calculateButton => _driver.FindElement(By.Id("calc_submit"));
        private IWebElement _resultBox => _driver.FindElement(By.CssSelector("#calc_result > div"));
        public VartuTechnikaPage(IWebDriver webdriver)
        {
            _driver = webdriver;
        }
        public void InsertWidth(string width)
        {
            _widthInput.Clear();
            _widthInput.SendKeys(width);
        }
        public void Insertheight(string height)
        {
            _heightInput.Clear();
            _heightInput.SendKeys(height);
        }
        public void InsertWidthAndheight(string width, string height)
        {
            InsertWidth(width);
            Insertheight(height);
        }
        public void CheckAutomaticCheckBox(bool shouldBeChecked)
        {
            if (shouldBeChecked != _autoCheckBox.Selected)
                _autoCheckBox.Click();
        }
        public void CheckMontavimoDarbaiCheckBox(bool shouldBeChecked)
        {
            if (shouldBeChecked != _montavimoCheckBox.Selected)
                _MontavimoCheckBox.Click();
        }
        public void ClickCalculateButton()
        {
            _calculateButton.Click();
        }
        private void waitForResult()
        {
            WebDriverWait wait = new WebDriverWait(_driver, Time.Span.FromSeconds(10));
            wait.Until(d => _resultBox.Displayed);
        }
        private void CheckResult (string expectedResult)
        {
            Assert.IsTrue(_resultBox.Text.Contains(expectedResult), $"result is not the same, expected {expectedResult}, but was {_resultBox.Text}");
        }
    }
}
