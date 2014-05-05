using System.Data.Entity;
using MySqlContext.Entities;

namespace MySqlContext.Interface.Articles
{
    public interface IArticleLocateRepository
    {
        DbSet<articleloc> Entity
        {
            get;
        }

        /// <summary>
        /// Get date Article by Id
        /// </summary>
        /// <param name="id">Identificaion store</param>
        /// <param name="locateId">Localization Id</param>
        /// <returns>articleloc model</returns>
        articleloc GetArticleById(int id, int locateId);
    }
}
