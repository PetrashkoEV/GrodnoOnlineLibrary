using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MySqlContext.Entities;
using MySqlContext.Interface.Articles;

namespace MySqlContext.Concrete.Articles
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly LibDbEntities _dataContext = new LibDbEntities();

        public DbSet<article> Entity
        {
            get
            {
                return _dataContext.article;
            }
        }

        public DbSet<articleloc> EntityArticlesLocate
        {
            get
            {
                return _dataContext.articleloc;
            }
        }

        public IQueryable<article> FindByCategoryes(List<long> categoryesId)
        {
            var result = Entity.Where(item => categoryesId.Contains(item.category));
            return result;
        }
    }
}
