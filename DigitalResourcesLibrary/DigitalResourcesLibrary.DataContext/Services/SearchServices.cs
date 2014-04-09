using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalResourcesLibrary.DataContext.Enums;
using DigitalResourcesLibrary.DataContext.Helper;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Model.Documents;
using MySqlContext.Concrete.Articles;
using MySqlContext.Concrete.Search;
using MySqlContext.Concrete.Store;
using MySqlContext.Interface.Articles;
using MySqlContext.Interface.Search;
using MySqlContext.Interface.Store;

namespace DigitalResourcesLibrary.DataContext.Services
{
    public class SearchServices : ISearchServices
    {
        private readonly ISearchRepository _searchRepository = new SearchRepository();
        private readonly IArticleRepository _articleRepository = new ArticleRepository();
        private readonly IStoreRepository _storeRepository = new StoreRepository();

        public List<string> AutoComplete(string search)
        {
            return _searchRepository.AutoComplite(search);
        }

        public List<DocumentModel> SearchDocumentsByCategory(int categoryId)
        {
            var allCategory = new List<long> {categoryId};

            var listStore = _storeRepository.FindByCategoryes(allCategory, 1);

            List<DocumentModel> result = new List<DocumentModel>();

            foreach (var store in listStore)
            {
                var storeloc = store.storeloc.FirstOrDefault();
                if (storeloc != null)
                {
                    result.Add(new DocumentModel
                    {
                        Id = store.id,
                        TypeDocument = TypeDocumentsHelper.GeTypeDocument("article"),
                        Locale = Language.ru,
                        ModifiedDate = store.modified.Value,
                        Description = storeloc.description,
                        Title = storeloc.title
                    });
                }
            }

            return result;
        }
    }
}
