using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUiTest.Component.Impl;

namespace WebUiTest.Entities
{
    internal class SearchResultItem
    {
        public string Title { get; }
        public string Description { get; }

        public SearchResultItem(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public override bool Equals(object? obj)
        {
            return obj is SearchResultItem item &&
                   Title == item.Title &&
                   Description == item.Description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Description);
        }

        public override string ToString()
        {
            return $"{nameof(SearchResultItem)} : \n" +
                $"{nameof(Title)} = {Title}\n" + 
                $"{nameof(Description)} = {Description}";
        }
    }

}
