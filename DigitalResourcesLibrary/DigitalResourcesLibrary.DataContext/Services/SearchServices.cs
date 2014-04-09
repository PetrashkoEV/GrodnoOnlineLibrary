using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DigitalResourcesLibrary.DataContext.Enums;
using DigitalResourcesLibrary.DataContext.Helper;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Model;
using DigitalResourcesLibrary.DataContext.Model.Documents;
using MySqlContext.Concrete.Articles;
using MySqlContext.Concrete.Search;
using MySqlContext.Concrete.Store;
using MySqlContext.Entities;
using MySqlContext.Interface.Articles;
using MySqlContext.Interface.Search;
using MySqlContext.Interface.Store;

namespace DigitalResourcesLibrary.DataContext.Services
{
    public class SearchServices : ISearchServices
    {
        private readonly ISearchRepository _searchRepository = new SearchRepository();
        private readonly IArticleService _articleService = new ArticleService();

        private readonly IStoreService _storeService = new StoreServices();

        public List<string> AutoComplete(string search)
        {
            return _searchRepository.AutoComplite(search);
        }

        public List<DocumentModel> SearchDocumentsByCategory(int categoryId)
        {
            var allCategory = new List<long> {categoryId};

            var result = new List<DocumentModel>();
            result.AddRange(_articleService.FindByCategoryes(allCategory));
            //result.AddRange(_storeService.FindByCategoryes(allCategory));
            
            return result;
        }

    }
}
