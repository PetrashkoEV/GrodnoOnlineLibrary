using System.Data.Entity;
using System.Linq;
using MySqlContext.Entities;

namespace MySqlContext.Interface.Categories
{
    public interface ICategoryRepository
    {
        DbSet<category> Entity
        {
            get;
        }

        /// <summary>
        /// Returns all sub-categories in this category
        /// </summary>
        /// <param name="id">Identificator parent category</param>
        /// <returns></returns>
        IQueryable<long> GetAllIdSubCategory(int id);

        /// <summary>
        /// Getting category name on ID
        /// </summary>
        /// <param name="id">Identificator category</param>
        /// <param name="locateId">Identificator localization</param>
        /// <returns>Name category</returns>
        string GetNameCategoryById(int id, int locateId);
    }
}
