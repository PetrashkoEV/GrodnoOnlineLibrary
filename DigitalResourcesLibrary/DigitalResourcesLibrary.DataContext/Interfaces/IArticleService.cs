using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalResourcesLibrary.DataContext.Model.Documents;
using MySqlContext.Entities;

namespace DigitalResourcesLibrary.DataContext.Interfaces
{
    public interface IArticleService
    {
        /// <summary>
        /// The total number of elements. Updated only after the search operation
        /// </summary>
        int CountArticle { get; }

        /// <summary>
        /// Getting the Article Model by Id
        /// </summary>
        /// <param name="id">Identificator Article</param>
        /// <returns>Article Model</returns>
        ArticleModel GetArticleById(int id);

        /// <summary>
        /// Search all the data for categories
        /// </summary>
        /// <param name="allCategory">List categories</param>
        /// <param name="page">Number curent page</param>
        /// <returns>List all article data</returns>
        List<DocumentModel> FindByCategoryes(List<long> allCategory, int page);

        /// <summary>
        /// Search all article by date
        /// </summary>
        /// <param name="date">Date create record in article table</param>
        /// <param name="page">Number curent page</param>
        /// <returns>List all article data</returns>
        List<DocumentModel> FindByDate(DateTime date, int page);

        /// <summary>
        /// Search all article by List Id
        /// </summary>
        /// <param name="articleIds">List article Id</param>
        /// <param name="page">Number curent page</param>
        /// <returns>List all article data</returns>
        List<DocumentModel> FindByArticleId(List<int> articleIds, int page);

        /// <summary>
        /// Сonversion List Tag In Document Models
        /// </summary>
        /// <param name="articleListAlls">List all article</param>
        /// <returns>List all article data</returns>
        List<DocumentModel> ConverListTagInDocumentModels(IEnumerable<article> articleListAlls);
    }
}
