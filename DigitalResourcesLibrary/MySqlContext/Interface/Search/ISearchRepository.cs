using System.Collections.Generic;
using MySqlContext.Model;

namespace MySqlContext.Interface.Search
{
    public interface ISearchRepository
    {
        /// <summary>
        /// AutoComplite full-text search database
        /// </summary>
        /// <param name="searchString">String search</param>
        /// <returns>limited number of items returned</returns>
        List<SphinxSearchResult> AutoComplite(string searchString);

        /// <summary>
        /// full-text search database
        /// </summary>
        /// <param name="searchString">String search</param>
        /// <returns>All items</returns>
        List<SphinxSearchResult> SearchText(string searchString);

        /// <summary>
        /// Advanced Search by tag, category
        /// </summary>
        /// <param name="tagId">Search id tags list</param>
        /// <param name="categoryId">Search id category list</param>
        /// <param name="searchString">String search</param>
        /// <returns>All items</returns>
        List<SphinxSearchResult> AdvancedSearch(List<int> tagId, List<long> categoryId, string searchString);
    }
}