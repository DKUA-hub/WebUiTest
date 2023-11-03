using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUiTest.Pages.Impl
{
    internal class SearchResultsPage : WebPage
    {
        private IList<IWebElement> _result => FindElements(By.CssSelector(".s-main-slot h2 .a-link-normal"));
        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
            
        }

        public IList<string> SearchResultItemText()
        {
            return _result
                .Select(item => item.Text.ToLower())
                .ToList();
        }

        public IList<string> SearchResultItemWithText(string searchWord)
        {
            return SearchResultItemText()
                .Where(item => item.Contains(searchWord))
                .ToList();
        }
    }
}
