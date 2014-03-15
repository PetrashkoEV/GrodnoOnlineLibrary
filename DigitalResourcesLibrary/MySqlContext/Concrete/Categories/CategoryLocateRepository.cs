using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using MySqlContext.Entities;
using MySqlContext.Interface.Categories;

namespace MySqlContext.Concrete.Categories
{
    public class CategoryLocateRepository : ICategoryLocateRepository
    {
        private LibDbEntities _dataContext = new LibDbEntities();

        public DbSet<categoryloc> Entity
        {
            get
            {
                return _dataContext.categoryloc;
            }
        }
    }
}