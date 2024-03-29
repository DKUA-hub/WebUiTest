﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUiTest.Component.Impl
{
    internal class SearchComponent : WebComponent
    {
        public SearchComponent(IWebElement rootElement) : base(rootElement)
        { 
        }

        public void PerformSearch(string searchPhrase)
        {
            SendKeys(searchPhrase);
            SendKeys(Keys.Enter);
        }
    }
}
