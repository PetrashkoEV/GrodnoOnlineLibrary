using System.Data.Entity;
using System.Linq;
using MySqlContext.Entities;
using MySqlContext.Model;

namespace MySqlContext.Interface.Categories
{
    public interface ICategoryLocateRepository
    {
        DbSet<categoryloc> Entity
        {
            get;
        }

        /// <summary>
        /// Search in db by search string
        /// </summary>
        /// <param name="search">search string</param>
        /// <returns>list categoryes result</returns>
        IQueryable<SphinxSearchResult> Search(string search);
    }
}
