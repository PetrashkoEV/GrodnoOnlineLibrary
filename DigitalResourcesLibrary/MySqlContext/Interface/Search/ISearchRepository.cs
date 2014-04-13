using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
