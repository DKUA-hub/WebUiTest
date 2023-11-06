using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUiTest.Component.Impl;

namespace WebUiTest.Pages.Impl
{
    internal class HomePage : WebPage
    {
        private static readonly By SearchComponentSelector = By.CssSelector("#twotabsearchtextbox");
        public HomePage(IWebDriver driver) : base(driver) { }

        public SearchComponent SearchComponent => new SearchComponent(FindElement(SearchComponentSelector));
    }
}
