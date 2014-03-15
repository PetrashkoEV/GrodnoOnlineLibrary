using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using MySqlContext.Entities;
using MySqlContext.Interface.Categories;

namespace MySqlContext.Concrete.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private LibDbEntities _dataContext = new LibDbEntities();

        public DbSet<category> Entity
        {
            get
            {
                return _dataContext.category;
            }
        }
    }
}
