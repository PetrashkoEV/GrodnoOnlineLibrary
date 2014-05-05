using System.Data.Entity;
using MySqlContext.Concrete;
using MySqlContext.Concrete.Store;
using MySqlContext.Entities;
using MySqlContext.Model;

namespace MySqlContext.Interface.Store
{
    public interface IStoreLocateRepository
    {
        /// <summary>
        /// Data context entity for Storeloc table
        /// </summary>
        DbSet<storeloc> Entity
        {
            get;
        }

        /// <summary>
        /// Get Store model by Id
        /// </summary>
        /// <param name="id">Identificaion store</param>
        /// <param name="locateId">Localization Id</param>
        /// <returns>Store model</returns>
        storeloc GetStoreById(int id, int locateId);

        /// <summary>
        /// Getting lightweight data model by id
        /// </summary>
        /// <param name="id">Identificaion store</param>
        /// <param name="locateId">Localization Id</param>
        /// <returns>Lightweight data storeloc model (title, discription)</returns>
        storeloclight GetStoreByIdWithoutData(int id, int locateId);
    }
}
