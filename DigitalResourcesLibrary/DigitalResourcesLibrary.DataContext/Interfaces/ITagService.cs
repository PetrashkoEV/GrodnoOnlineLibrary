using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalResourcesLibrary.DataContext.Enums;
using DigitalResourcesLibrary.DataContext.Model;
using DigitalResourcesLibrary.DataContext.Model.Documents;
using MySqlContext.Model;

namespace DigitalResourcesLibrary.DataContext.Interfaces
{
    public interface ITagService
    {
        /// <summary>
        /// Get all list tags of Db
        /// </summary>
        /// <returns>list TagModel</returns>
        List<TagModel> GetAllTags();

        /// <summary>
        /// Receiving all types of documents based on localization
        /// </summary>
        /// <returns>list of file types</returns>
        List<string> GetAllFileType();

        /// <summary>
        /// Split a string with tags in a list TagModel
        /// </summary>
        /// <param name="tagSelect">string with tags</param>
        /// <returns>list TagModel</returns>
        List<TagModel> TagSelectSplit(string tagSelect);

        /// <summary>
        /// Split a string with fileDocuments in a list FileType
        /// </summary>
        /// <param name="fileDocumentsSelect">string with fileDocuments</param>
        /// <returns>list FileType</returns>
        List<FileType> FileTypeSplit(string fileDocumentsSelect);

        /// <summary>
        /// Auto Complite search in tags
        /// </summary>
        /// <param name="search">Search string</param>
        /// <returns>list Sphinx Search Result</returns>
        List<SphinxSearchResult> AutoComplite(string search);
    }
}
