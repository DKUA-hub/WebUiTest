using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUiTest.Component.Impl;

namespace WebUiTest.Pages.Impl
{
    internal class SearchResultsPage : WebPage
    {
        private static readonly By SearchResultItemSelector = By.CssSelector(".s-main-slot h2 .a-link-normal");

        private IList<SearchResultItemComponent> SearchResultItems => 
            FindElements(SearchResultItemSelector)
                .Select(item => new SearchResultItemComponent(item))
                .ToList();
        public SearchResultsPage(IWebDriver driver) : base(driver)
        {            
        }

        public IList<string> SearchResultItemText()
        {
            return SearchResultItems
                .Select(item => item.Text)
                .ToList();
        }

        public IList<string> SearchResultItemWithText(string searchPhrase)
        {
            return SearchResultItems
                .Where(item => item.ContainsSearchText(searchPhrase))
                .Select(item => item.Text)
                .ToList();
        }
    }
}
