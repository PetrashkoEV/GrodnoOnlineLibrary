using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DigitalResourcesLibrary.DataContext.Enums;
using DigitalResourcesLibrary.DataContext.Helper;
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
        private readonly ICategoryService _categoryService = new CategoryService();
        private readonly int _countNewsOnPage = DocumentsHelper.CountNewsOnPage;

        public List<string> AutoComplete(string search)
        {
            return _searchRepository.AutoComplite(search);
        }

        public List<DocumentModel> SearchDocumentsByCategory(int categoryId, int page)
        {
            var allCategory = _categoryService.GetIdAllSybCategory(categoryId);
            allCategory.Add(categoryId); // add curent category

            var allCollectionResult = new List<DocumentModel>();
            allCollectionResult.AddRange(_articleService.FindByCategoryes(allCategory, page)); // all article entries with the category
            allCollectionResult.AddRange(_storeService.FindByCategoryes(allCategory, page)); // all store entries with the category

            return CreationDocumentsToDisplay(allCollectionResult, page);
        }

        public List<DocumentModel> SearchDocumentsByDate(DateTime date, int page)
        {
            var allCollectionResult = new List<DocumentModel>();
            allCollectionResult.AddRange(_articleService.FindByDate(date, page)); // all article entries with the category
            allCollectionResult.AddRange(_storeService.FindByDate(date, page)); // all store entries with the category

            var result = CreationDocumentsToDisplay(allCollectionResult, page);
            return result;
        }

        public int CountPages()
        {
            return
                (int) Math.Ceiling((_articleService.CountArticle + _storeService.CountStore)/(double) _countNewsOnPage);
        }

        /// <summary>
        /// Based all list documents formation list to display the current page
        /// </summary>
        /// <param name="listDocumentModels">Full list of documents</param>
        /// <param name="page">Number of page</param>
        /// <returns>List of documents suitable for display on the page</returns>
        private List<DocumentModel> CreationDocumentsToDisplay(IEnumerable<DocumentModel> listDocumentModels, int page)
        {
            var result = listDocumentModels
                .OrderByDescending(item => item.ModifiedDate)
                .Skip(_countNewsOnPage * (page - 1))
                .Where(item =>
                        (item.TypeDocument == TypeDocument.Article) ||
                        (_storeService.FindContentStoreById(item.Id).Title != null))
                .Take(_countNewsOnPage).ToList();

            foreach (var documentModel in result)
            {
                if (documentModel.TypeDocument == TypeDocument.Store)
                {
                    var store = _storeService.FindContentStoreById(documentModel.Id);
                    documentModel.Title = store.Title;
                    documentModel.Description = store.Description;
                }
            }
            return result;
        }
    }
}
