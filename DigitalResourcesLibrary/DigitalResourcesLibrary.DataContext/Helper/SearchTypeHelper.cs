using System;
using DigitalResourcesLibrary.DataContext.Enums;

namespace DigitalResourcesLibrary.DataContext.Helper
{
    public static class SearchTypeHelper
    {
        private const string Tag = "tag";
        private const string Category = "category";

        public static SearchType GeTypeDocument(string searchType)
        {
            if (String.Compare(searchType, Tag, StringComparison.CurrentCultureIgnoreCase) == 0)
            {
                return SearchType.Tag;
            }
            return SearchType.Category;
        }

        public static string GeTypeDocument(SearchType searchType)
        {
            if (searchType == SearchType.Tag)
            {
                return Tag;
            }
            return Category;
        }
    }
}
