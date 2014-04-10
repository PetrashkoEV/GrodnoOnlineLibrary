using System.Collections.Generic;
using System.Linq;
using DigitalResourcesLibrary.DataContext.Enums;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Model.Documents;
using MySqlContext.Concrete.Search;
using MySqlContext.Interface.Search;

namespace DigitalResourcesLibrary.DataContext.Services
{
    public class SearchServices : ISearchServices
    {
        private readonly ISearchRepository _searchRepository = new SearchRepository();
        private readonly IArticleService _articleService = new ArticleService();
        private readonly IStoreService _storeService = new StoreServices();

        private int countNews = 5;

        public List<string> AutoComplete(string search)
        {
            return _searchRepository.AutoComplite(search);
        }

        public List<DocumentModel> SearchDocumentsByCategory(int categoryId)
        {
            var allCategory = new List<long> {categoryId};

            var allCollectionResult = new List<DocumentModel>();
            allCollectionResult.AddRange(_articleService.FindByCategoryes(allCategory)); // all article entries with the category
            allCollectionResult.AddRange(_storeService.FindByCategoryes(allCategory)); // all store entries with the category

            allCollectionResult.OrderBy(item => item.ModifiedDate);

            // allocation interval for displaying news
            var result = new List<DocumentModel>();
            var countCollection = 0;
            foreach (var documentModel in allCollectionResult)
            {
                if (countCollection < countNews)
                {
                    if (documentModel.TypeDocument == TypeDocument.Store)
                    {
                        var store = _storeService.FindContentStoreById(documentModel.Id); // get light store model without byte data
                        if (store.Title != null && store.Description != null) // no value for the current locale
                        {
                            documentModel.Title = store.Title;
                            documentModel.Description = store.Description;
                            result.Add(documentModel);
                            countCollection++;
                        }
                    }
                    else
                    {
                        result.Add(documentModel);
                        countCollection++;
                    }
                    
                }
            }

            return result;
        }

    }
}
