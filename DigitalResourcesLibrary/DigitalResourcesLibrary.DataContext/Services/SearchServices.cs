using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DigitalResourcesLibrary.DataContext.Enums;
using DigitalResourcesLibrary.DataContext.Helper;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Model;
using DigitalResourcesLibrary.DataContext.Model.Documents;
using MySqlContext.Concrete.Search;
using MySqlContext.Interface.Search;
using MySqlContext.Model;

namespace DigitalResourcesLibrary.DataContext.Services
{
    public class SearchServices : ISearchServices
    {
        private readonly ISearchRepository _searchRepository = new SearchRepository();
        private readonly IArticleService _articleService = new ArticleService();
        private readonly IStoreService _storeService = new StoreServices();
        private readonly ICategoryService _categoryService = new CategoryService();
        private readonly ITagService _tagService = new TagService();
        private readonly int _countNewsOnPage = DocumentsHelper.CountNewsOnPage;
        private const int CountSumbolInSearchText = 40;

        public List<string> AutoComplete(string search)
        {
            var result = new List<string>();
            var fullTextSearch = _searchRepository.AutoComplite(search);
            foreach (var fullText in fullTextSearch)
            {
                bool matchFoundInTitle = true;
                string fullString = fullText.Ttile;
                var position = GetPositionSearchText(fullText, search, ref matchFoundInTitle);

                if (!matchFoundInTitle)
                {
                    fullString = fullText.Decription;
                }

                string prefixText = fullString.Remove(position); // full text of the line to the desired combination of symbols
                if (prefixText != "") //beginning of a word selection
                {
                    prefixText = prefixText.Remove(0, prefixText.LastIndexOf(" "));
                }

                string newText = prefixText + fullString.Substring(position, search.Count()); // the beginning and the root of the word

                string completionText = fullString.Remove(0, position + search.Count()); //Full text after the search string
                if (CountSumbolInSearchText - newText.Count() < completionText.Count())
                {
                    completionText = completionText.Remove(CountSumbolInSearchText - newText.Count()); // trimming line
                    completionText = completionText.Remove(completionText.LastIndexOf(" ")); //search word endings
                }
                
                result.Add(newText + completionText);
            }
            return result;
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

        public List<DocumentModel> SearchDocumentsByText(string searchText, int page)
        {
            var allSearchList = _searchRepository.SearchText(searchText);

            var articleIdList = new List<int>();
            var storeIdList = new List<int>();
            foreach (var searchResult in allSearchList)
            {
                var type = TypeDocumentsHelper.GeTypeDocument(searchResult.TypeDocument);
                switch (type)
                {
                    case TypeDocument.Article:
                        articleIdList.Add(searchResult.Id);
                        break;
                    case TypeDocument.Store:
                        storeIdList.Add(searchResult.Id);
                        break;
                }
            }

            var allCollectionResult = new List<DocumentModel>();
            allCollectionResult.AddRange(_articleService.FindByArticleId(articleIdList, page)); // all article entries with the List Id
            allCollectionResult.AddRange(_storeService.FindByStoreId(articleIdList, page)); // all store entries with the List Id

            return CreationDocumentsToDisplay(allCollectionResult, page);
        }

        public int CountPages()
        {
            return
                (int) Math.Ceiling((_articleService.CountArticle + _storeService.CountStore)/(double) _countNewsOnPage);
        }

        public List<DocumentModel> AdvancedSearch(string textSearch, string tagSelect, string formatDocSelect, 
                                                    int categoryId, int page)
        {
            var tagsId = _tagService.TagSelectSplit(tagSelect).Select(item => item.Id).ToList();
            var category = _categoryService.GetIdAllSybCategory(categoryId);
            var typeDocuments = _tagService.FileTypeSplit(formatDocSelect);

            var allSearchList = _searchRepository.AdvancedSearch(tagsId, category, textSearch);

            var articleIdList = new List<int>();
            var storeIdList = new List<int>();
            foreach (var searchResult in allSearchList)
            {
                var type = TypeDocumentsHelper.GeTypeDocument(searchResult.TypeDocument);
                switch (type)
                {
                    case TypeDocument.Article:
                        articleIdList.Add(searchResult.Id);
                        break;
                    case TypeDocument.Store:
                        storeIdList.Add(searchResult.Id);
                        break;
                }
            }

            var allCollectionResult = new List<DocumentModel>();
            allCollectionResult.AddRange(_articleService.FindByArticleId(articleIdList, page)); // all article entries with the List Id
            allCollectionResult.AddRange(_storeService.FindByStoreId(articleIdList, page)); // all store entries with the List Id

            return CreationDocumentsToDisplay(allCollectionResult, page, typeDocuments);
        }

        /// <summary>
        /// Based all list documents formation list to display the current page
        /// </summary>
        /// <param name="listDocumentModels">Full list of documents</param>
        /// <param name="page">Number of page</param>
        /// <returns>List of documents suitable for display on the page</returns>
        private List<DocumentModel> CreationDocumentsToDisplay(IEnumerable<DocumentModel> listDocumentModels, int page, List<FileType> fileTypes = null)
        {
            var result = listDocumentModels
                .OrderByDescending(item => item.ModifiedDate)
                .Skip(_countNewsOnPage * (page - 1))
                .Where(item => (item.TypeDocument == TypeDocument.Article) || 
                    (_storeService.FindContentStoreById(item.Id).Title != null));

            if (fileTypes != null && fileTypes.Count != 0)
            {
                result = result.Where(item => fileTypes.Contains(item.Type));
            }

            result = result.Take(_countNewsOnPage).ToList();

            foreach (var documentModel in result)
            {
                if (documentModel.TypeDocument == TypeDocument.Store)
                {
                    var store = _storeService.FindContentStoreById(documentModel.Id);
                    documentModel.Title = store.Title;
                    documentModel.Description = store.Description;
                }
            }
            return (List<DocumentModel>) result;
        }

        private int GetPositionSearchText(SphinxSearchResult autoCompliteResult, string search, ref bool matchFoundInTitle)
        {
            var position = autoCompliteResult.Ttile.IndexOf(search, System.StringComparison.CurrentCultureIgnoreCase);
            matchFoundInTitle = true;
            if (position < 0)
            {
                matchFoundInTitle = false;
                position = autoCompliteResult.Decription.IndexOf(search, System.StringComparison.CurrentCultureIgnoreCase);
            }
            if (position < 0)
            {
                position = GetPositionSearchText(autoCompliteResult, search.Remove(search.Count() - 1), ref matchFoundInTitle);
            }
            return position;
        }
    }
}
