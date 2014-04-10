using System.Collections.Generic;
using DigitalResourcesLibrary.DataContext.Model.Documents;

namespace DigitalResourcesLibrary.DataContext.Interfaces
{
    public interface ISearchServices
    {
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
        /// <returns>List Documents Model</returns>
        List<DocumentModel> SearchDocumentsByCategory(int categoryId);
    }
}