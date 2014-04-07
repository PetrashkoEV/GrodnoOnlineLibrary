using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalResourcesLibrary.DataContext.Interfaces;
using MySqlContext.Concrete.Search;
using MySqlContext.Interface.Search;

namespace DigitalResourcesLibrary.DataContext.Services
{
    public class SearchServices : ISearchServices
    {
        private readonly ISearchRepository _searchRepository = new SearchRepository();

        public List<string> AutoComplete(string search)
        {
            return _searchRepository.AutoComplite(search);
        }
    }
}
