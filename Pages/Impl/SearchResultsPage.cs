using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUiTest.Component.Impl;
using WebUiTest.Entities;

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

        public IList<SearchResultItem> SearchResultsItems()
        {
            return SearchResultItems
                .Select(item => item.ConvertToSearchResultItem())
                .ToList();
        }

        public IList<SearchResultItem> SearchResultItemWithText(string searchPhrase)
        {
            return SearchResultsItems()
                .Where(item => item.Title.Contains(searchPhrase) ||
                                item.Description.Contains(searchPhrase))
                .ToList();
        }
    }
}
