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
        /// Getting the Store Model by Id
        /// </summary>
        /// <param name="id">Identificator store</param>
        /// <returns>Store Model</returns>
        StoreModel GetStoreById(int id);

        /// <summary>
        /// Search all the data for categories
        /// </summary>
        /// <param name="allCategory">List categories</param>
        /// <returns>List all store data</returns>
        List<DocumentModel> FindByCategoryes(List<long> allCategory);

        /// <summary>
        /// Search Title and Desription StoreLocate table by Id
        /// </summary>
        /// <param name="id">Identificator store</param>
        /// <returns>Ligth version storelocate model</returns>
        DocumentModel FindContentStoreById(int id);
    }
}
