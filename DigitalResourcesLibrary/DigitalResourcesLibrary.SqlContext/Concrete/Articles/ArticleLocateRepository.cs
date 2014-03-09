using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DigitalResourcesLibrary.SqlContext.Entities;
using DigitalResourcesLibrary.SqlContext.Interface.Articles;

namespace DigitalResourcesLibrary.SqlContext.Concrete.Articles
{
    public class ArticleLocateRepository : IArticleLocateRepository
    {
        private digitalresourceslibraryEntities _dataContext = new digitalresourceslibraryEntities();

        public DbSet<articleloc> Entity
        {
            get
            {
                return _dataContext.articleloc;
            }
        }
    }
}
