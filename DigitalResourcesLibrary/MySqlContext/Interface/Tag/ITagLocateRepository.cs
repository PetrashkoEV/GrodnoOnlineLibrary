using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MySqlContext.Entities;
using MySqlContext.Model;

namespace MySqlContext.Interface.Tag
{
    public interface ITagLocateRepository
    {
        DbSet<tagloc> Entity
        {
            get;
        }

        /// <summary>
        /// Search in db by search string
        /// </summary>
        /// <param name="search">search string</param>
        /// <returns>list tags result</returns>
        IQueryable<SphinxSearchResult> Search(string search);
    }
}
