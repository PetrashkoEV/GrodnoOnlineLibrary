using System.Data.Entity;
using DigitalResourcesLibrary.SqlContext.Entities;
using DigitalResourcesLibrary.SqlContext.Interface.Articles;

namespace DigitalResourcesLibrary.SqlContext.Concrete.Articles
{
    public class ArticleRepository : IArticleRepository
    {
        private digitalresourceslibraryEntities _dataContext = new digitalresourceslibraryEntities();

        public DbSet<article> Entity
        {
            get
            {
                return _dataContext.article;
            }
        }
    }
}
