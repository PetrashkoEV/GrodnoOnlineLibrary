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

        public IQueryable<long> GetAllIdSubCategory(int id)
        {
            return Entity.Where(item => item.parent == id).Select(item => item.id);
        }

        public string GetNameCategoryById(int id, int locateId)
        {
            return _dataContext.categoryloc.Where(item => item.category == id && item.locale == locateId).Select(item => item.value).FirstOrDefault();
        }
    }
}
