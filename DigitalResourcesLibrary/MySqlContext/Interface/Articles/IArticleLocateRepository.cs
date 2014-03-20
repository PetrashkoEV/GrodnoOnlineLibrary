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

        articleloc GetArticleById(int id);
    }
}
