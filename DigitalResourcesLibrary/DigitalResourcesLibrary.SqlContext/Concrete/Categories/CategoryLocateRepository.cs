using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DigitalResourcesLibrary.SqlContext.Entities;
using DigitalResourcesLibrary.SqlContext.Interface.Categories;

namespace DigitalResourcesLibrary.SqlContext.Concrete.Categories
{
    public class CategoryLocateRepository : ICategoryLocateRepository
    {
        private digitalresourceslibraryEntities _dataContext = new digitalresourceslibraryEntities();

        public DbSet<categoryloc> Entity
        {
            get
            {
                return _dataContext.categoryloc;
            }
        }
    }
}