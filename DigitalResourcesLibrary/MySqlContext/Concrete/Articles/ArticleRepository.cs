using System.Data.Entity;
using MySqlContext.Entities;
using MySqlContext.Interface.Articles;

namespace MySqlContext.Concrete.Articles
{
    public class ArticleRepository : IArticleRepository
    {
        private LibDbEntities _dataContext = new LibDbEntities();

        public DbSet<article> Entity
        {
            get
            {
                return _dataContext.article;
            }
        }
    }
}
