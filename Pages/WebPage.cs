using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUiTest.Pages
{
    internal class WebPage
    {
        private IWebDriver _driver;
        protected WebPage(IWebDriver driver)
        {
            _driver = driver;
        }

        protected IList<IWebElement> FindElements(By bySelector)
        {
            return _driver.FindElements(bySelector);
        }

        protected IWebElement FindElement(By bySelector)
        {
            return _driver.FindElement(bySelector);
        }
    }
}
