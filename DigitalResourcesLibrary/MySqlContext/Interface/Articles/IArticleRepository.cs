using System.Data.Entity;
using MySqlContext.Entities;

namespace MySqlContext.Interface.Articles
{
    public interface IArticleRepository
    {
        DbSet<article> Entity
        {
            get;
        }
    }
}
