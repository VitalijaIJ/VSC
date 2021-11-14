using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatinisTestavimas.Page
{
    class SeleniumCheckBoxPage
    {
        private IWebDriver _driver;
        private IWebElement _checkBox => _driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement _text => _driver.FindElement(By.Id("txtAge"));       
        private IWebElement _firstCheckbox => _driver.FindElement(By.Id(".cb1-element"));
        private IReadOnlyCollection<IWebElement> _multipleCheckboxList => _driver.FindElements(By.ClassName(".cb1-element"));
        private IWebElement _button => _driver.FindElement(By.Id("check1"));
        private IWebElement _resultFromPage => _driver.FindElement(By.Id("value"));

        public SeleniumCheckBoxPage (IWebDriver webdriver)
        {
            _driver = webdriver;
        }
        public void MarkCheckBox()
        {
            _checkBox.Click();
        }
        public void CheckTextResult(string text)
        {
            Assert.IsTrue(_text.Text.Equals("Success - Check box is checked"));
        }
        public void FirstCheckBoxClick()
        {
            if (_firstCheckbox.Selected)
                _firstCheckbox.Click();            
        }
        public SeleniumCheckBoxPage MultipleCheckboxClick()
        {
            FirstCheckBoxClick();
            foreach (IWebElement element in _multipleCheckboxList)
            {
                if(!element.Selected)
                element.Click();
            }
            return this;
        }
        public void ButtonName()
        {
            Assert.IsTrue(_button.GetAttribute("value").Equals("Uncheck All"), "Second is wrong");
        }

        public void ButtonClick()
        {
            if (_button.GetAttribute("value") == "Uncheck All")
                _button.Click();
        }
        public void MultipleCheckboxList()
        {
            int counter = 0;
            foreach (IWebElement element in _multipleCheckboxList)
            {
                if (element.Selected)
                {
                    counter++;
                }
            }
            Assert.AreEqual(0, counter, "Not all boxes unchecked");
        }

    }
}

