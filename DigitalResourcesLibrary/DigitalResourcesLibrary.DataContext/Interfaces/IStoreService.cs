using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalResourcesLibrary.DataContext.Model.Documents;

namespace DigitalResourcesLibrary.DataContext.Interfaces
{
    public interface IStoreService
    {
        /// <summary>
        /// The total number of elements. Updated only after the search operation
        /// </summary>
        int CountStore { get;}

        /// <summary>
        /// Getting the Store Model by Id
        /// </summary>
        /// <param name="id">Identificator store</param>
        /// <returns>Store Model</returns>
        StoreModel GetStoreById(int id);

        /// <summary>
        /// Search Title and Desription StoreLocate table by Id
        /// </summary>
        /// <param name="id">Identificator store</param>
        /// <returns>Ligth version storelocate model</returns>
        DocumentModel FindContentStoreById(int id);

        /// <summary>
        /// Search all the data for categories
        /// </summary>
        /// <param name="allCategory">List categories</param>
        /// <param name="page">Number curent page</param>
        /// <returns>List all store data</returns>
        List<DocumentModel> FindByCategoryes(List<long> allCategory, int page);

        /// <summary>
        /// Search all Store by date
        /// </summary>
        /// <param name="date">Date create record in article table</param>
        /// <param name="page">Number curent page</param>
        /// <returns>List all article data</returns>
        List<DocumentModel> FindByDate(DateTime date, int page);
    }
}
