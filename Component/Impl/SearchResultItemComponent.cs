using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUiTest.Component.Impl
{
    internal class SearchResultItemComponent : WebComponent
    {
        private static readonly By _titleSelector = By.CssSelector(".a-size-medium.a-color-base");
        private static readonly By _descriptionSelector = By.CssSelector(".a-size-medium.a-color-base.a-text-normal");

        public SearchResultItemComponent(IWebElement rootElement) : base(rootElement) 
        {
        }

        public bool ContainsSearchText(string searchPhrase)
        {
            return ContainsSearchTextIgnoringCase(searchPhrase, _titleSelector) ||
                ContainsSearchTextIgnoringCase(searchPhrase, _descriptionSelector);
        }

        private bool ContainsSearchTextIgnoringCase(string searchPhrase, By selector)
        {
            return FindElement(selector).Text.ToLower().Contains(searchPhrase.ToLower());
        }
    }
}
