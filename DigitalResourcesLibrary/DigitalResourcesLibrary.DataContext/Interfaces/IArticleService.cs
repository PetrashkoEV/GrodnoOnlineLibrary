using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalResourcesLibrary.DataContext.Model.Documents;

namespace DigitalResourcesLibrary.DataContext.Interfaces
{
    public interface IArticleService
    {
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
        /// <returns>List all article data</returns>
        List<DocumentModel> FindByCategoryes(List<long> allCategory);
    }
}
