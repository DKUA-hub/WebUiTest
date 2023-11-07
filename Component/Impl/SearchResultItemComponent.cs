using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUiTest.Entities;

namespace WebUiTest.Component.Impl
{
    internal class SearchResultItemComponent : WebComponent
    {
        private static readonly By _titleSelector = By.CssSelector(".a-size-medium.a-color-base");
        private static readonly By _descriptionSelector = By.CssSelector(".a-size-medium.a-color-base.a-text-normal");

        public SearchResultItemComponent(IWebElement rootElement) : base(rootElement) 
        {
        }

        public SearchResultItem ConvertToSearchResultItem() =>
            new SearchResultItem(
                FindElement(_titleSelector).Text.ToLower(),
                FindElement(_descriptionSelector).Text.ToLower());
    }
}
