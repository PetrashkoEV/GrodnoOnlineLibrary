using System;
using System.Collections.Generic;
using DigitalResourcesLibrary.DataContext.Model.Documents;

namespace DigitalResourcesLibrary.DataContext.Interfaces
{
    public interface ISearchServices
    {
        /// <summary>
        /// The total number of elements. Updated only after the search operation
        /// </summary>
        int CountPages();

        /// <summary>
        /// Full-text search in the database
        /// </summary>
        /// <param name="search">string is to be searched</param>
        /// <returns>Result fulltext search</returns>
        List<string> AutoComplete(string search);

        /// <summary>
        /// Search all the data (article, store table) for top-level categories
        /// </summary>
        /// <param name="categoryId">Identificator top-level category</param>
        /// <param name="page">Number curent page</param>
        /// <returns>List Documents Model</returns>
        List<DocumentModel> SearchDocumentsByCategory(int categoryId, int page);

        /// <summary>
        /// Search all data (article, store table) by date
        /// </summary>
        /// <param name="date">Identificator top-level category</param>
        /// <param name="page">Number curent page</param>
        /// <returns>List Documents Model</returns>
        List<DocumentModel> SearchDocumentsByDate(DateTime date, int page);

        /// <summary>
        /// Search all data (article, store table) by search text
        /// </summary>
        /// <param name="searchText">Symbols database search</param>
        /// <param name="page">Number curent page</param>
        /// <returns>List Documents Model</returns>
        List<DocumentModel> SearchDocumentsByText(string searchText, int page);

        /// <summary>
        /// full-text search by category, tag, document format
        /// </summary>
        /// <param name="textSearch">Text search</param>
        /// <param name="tagSelect">Tags</param>
        /// <param name="formatDocSelect">Format returns document</param>
        void AdvancedSearch(string textSearch, string tagSelect, string formatDocSelect);
    }
}