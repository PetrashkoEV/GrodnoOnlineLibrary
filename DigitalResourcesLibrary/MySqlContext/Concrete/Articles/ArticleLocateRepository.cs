using System.Data.Entity;
using System.Linq;
using MySqlContext.Entities;
using MySqlContext.Interface.Articles;

namespace MySqlContext.Concrete.Articles
{
    public class ArticleLocateRepository : IArticleLocateRepository
    {
        private LibDbEntities _dataContext = new LibDbEntities();

        public DbSet<articleloc> Entity
        {
            get
            {
                return _dataContext.articleloc;
            }
        }

        public articleloc GetArticleById(int id, int locateId)
        {
            return Entity.FirstOrDefault(item => item.article == id && item.locale == locateId);
        }
    }
}
