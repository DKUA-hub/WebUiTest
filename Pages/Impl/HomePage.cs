using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUiTest.Pages.Impl
{
    internal class HomePage : WebPage
    {
        private IWebElement searchElement => FindElement(By.CssSelector("#twotabsearchtextbox"));
        public HomePage(IWebDriver driver) : base(driver) { }

        public void PerformSearch(string searchWord)
        {
            searchElement.SendKeys(searchWord);
            searchElement.SendKeys(Keys.Enter);
        }
    }
}
