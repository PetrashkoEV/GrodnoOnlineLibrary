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
using MySqlContext.Concrete.Tag;
using MySqlContext.Interface.Search;
using MySqlContext.Interface.Tag;
using MySqlContext.Model;

namespace DigitalResourcesLibrary.DataContext.Services
{
    public class SearchService : ISearchService
    {
        private readonly ISearchRepository _searchRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IArticleService _articleService;
        private readonly IStoreService _storeService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;

        private readonly int _countNewsOnPage = DocumentsHelper.CountNewsOnPage;
        private const int CountSumbolInSearchText = 40;

        public SearchService(IArticleService articleService, IStoreService storeService,
                            ICategoryService categoryService, ITagService tagService)
        {
            this._searchRepository = new SearchRepository();
            this._tagRepository = new TagRepository();
            this._articleService = articleService;
            this._storeService = storeService;
            this._categoryService = categoryService;
            this._tagService = tagService;
        }
        public List<string> AutoComplete(string search)
        {
            var fullTextSearch = _tagService.AutoComplite(search);
            fullTextSearch.AddRange(_categoryService.AutoComplite(search));
            fullTextSearch.AddRange(_searchRepository.AutoComplite(search));
            return ReplaseResultSearch(fullTextSearch, search);
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
            var result = new List<DocumentModel>();

            var fullTextSearch = _categoryService.AutoComplite(searchText);
            fullTextSearch.AddRange(_tagService.AutoComplite(searchText));

            if (fullTextSearch.Count !=0) // search by category or tag
            {
                foreach (var searchResult in fullTextSearch)
                {
                    result.AddRange(SearchTypeHelper.GeTypeDocument(searchResult.SearchType) ==
                                                 SearchType.Category
                        ? SearchDocumentsByCategory(searchResult.Id, page)
                        : SearchDocumentByTag(searchResult.Id, page));
                }
            }
            else // search sphinx helper
            {
                result.AddRange(SearchDocumentInDb(searchText, page));
            }

            return result;
        }

        
        public List<DocumentModel> SearchDocumentByTag(int tagId, int page)
        {
            var allCollectionResult = new List<DocumentModel>();
            var tag = _tagRepository.Find(tagId);

            allCollectionResult.AddRange(_articleService.ConverListTagInDocumentModels(tag.article));
            allCollectionResult.AddRange(_storeService.ConverListTagInDocumentModels(tag.store));
            return CreationDocumentsToDisplay(allCollectionResult, page);
        }

        public int CountPages()
        {
            return
                (int)Math.Ceiling((_articleService.CountArticle + _storeService.CountStore) / (double)_countNewsOnPage);
        }

        public List<DocumentModel> AdvancedSearch(string textSearch, string tagSelect, string formatDocSelect,
                                                    string categorySelect, int page)
        {
            var tagsId = _tagService.TagSelectSplit(tagSelect).Select(item => item.Id).ToList();
            var category = _categoryService.CategorySelectSplit(categorySelect);
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
            allCollectionResult.AddRange(_storeService.FindByStoreId(storeIdList, page)); // all store entries with the List Id

            return CreationDocumentsToDisplay(allCollectionResult, page, typeDocuments);
        }

        /// <summary>
        /// Based all list documents formation list to display the current page
        /// </summary>
        /// <param name="listDocumentModels">Full list of documents</param>
        /// <param name="page">Number of page</param>
        /// <param name="fileTypes">File types for sorting</param>
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

            return (List<DocumentModel>)result;
        }

        /// <summary>
        /// Cropping Title or Discription depending on the desired text
        /// </summary>
        /// <param name="fullTextSearch"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        private List<string> ReplaseResultSearch(IEnumerable<SphinxSearchResult> fullTextSearch, string search)
        {
            var result = new List<string>();
            foreach (var fullText in fullTextSearch)
            {
                var fullString = fullText.Ttile;
                var position = getPositionSearchText(fullString, search);

                if (position < 0)
                {
                    fullString = fullText.Decription;
                    position = getPositionSearchText(fullString, search);
                }

                var prefixText = fullString.Remove(position); // full text of the line to the desired combination of symbols
                if (prefixText != String.Empty) //beginning of a word selection
                {
                    var removeIndex = prefixText.LastIndexOf(" ", System.StringComparison.Ordinal);
                    if (removeIndex != -1)
                    {
                        prefixText = prefixText.Remove(0, removeIndex);
                    }
                }

                var newText = prefixText + fullString.Substring(position, search.Count()); // the beginning and the root of the word

                var completionText = fullString.Remove(0, position + search.Count()); //Full text after the search string
                if (CountSumbolInSearchText - newText.Count() < completionText.Count())
                {
                    completionText = completionText.Remove(CountSumbolInSearchText - newText.Count()); // trimming line
                    var removeIndex = completionText.LastIndexOf(" ");
                    if (removeIndex != -1)
                    {
                        completionText = completionText.Remove(removeIndex); //search word endings
                    }
                }

                result.Add(newText + completionText);
            }
            return result;
        }

        /// <summary>
        /// Determination of the position of the substring
        /// </summary>
        /// <param name="autoCompliteResult">String</param>
        /// <param name="search">substring</param>
        /// <returns>Position substring</returns>
        private int getPositionSearchText(string autoCompliteResult, string search)
        {
            var position = autoCompliteResult.IndexOf(search, System.StringComparison.CurrentCultureIgnoreCase);
            return position;
        }

        private IEnumerable<DocumentModel> SearchDocumentInDb(string searchText, int page)
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
            allCollectionResult.AddRange(_storeService.FindByStoreId(storeIdList, page)); // all store entries with the List Id

            return CreationDocumentsToDisplay(allCollectionResult, page);
        }

    }
}
