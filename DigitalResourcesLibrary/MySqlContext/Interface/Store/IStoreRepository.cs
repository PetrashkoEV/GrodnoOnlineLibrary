using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MySqlContext.Entities;

namespace MySqlContext.Interface.Store
{
    public interface IStoreRepository
    {
        /// <summary>
        /// Data context entity for Store table
        /// </summary>
        DbSet<store> Entity
        {
            get;
        }

        /// <summary>
        /// Search stored in DB by ID
        /// </summary>
        /// <param name="id">Identification stored</param>
        /// <returns>store model</returns>
        store Find(int id);

        /// <summary>
        /// Search a file contained in stored table by ID
        /// </summary>
        /// <param name="id">Identification stored</param>
        /// <returns>Binary file contents</returns>
        IEnumerable<byte[]> FindFile(int id);

        /// <summary>
        /// Search all stores by category
        /// </summary>
        /// <param name="categoryesId">Identificaion category</param>
        /// <returns>Store model without model StoreLoc</returns>
        IQueryable<store> FindByCategoryes(List<long> categoryesId);

    }
}
