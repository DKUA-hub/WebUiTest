using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUiTest.Component
{
    internal class WebComponent
    {
        private IWebElement _rootElement;
        protected WebComponent(IWebElement rootElement)
        {
            _rootElement = rootElement;
        }

        protected IWebElement FindElement(By bySelector) =>
            _rootElement.FindElement(bySelector);

        protected void SendKeys(string searchPhrase) =>
            _rootElement.SendKeys(searchPhrase);

        public string Text =>
            _rootElement.Text;
    }
}
