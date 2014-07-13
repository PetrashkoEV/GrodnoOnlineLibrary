using System.Data.Entity;
using System.Linq;
using MySqlContext.Entities;
using MySqlContext.Interface.Categories;
using MySqlContext.Model;

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

        public IQueryable<SphinxSearchResult> Search(string search)
        {
            return Entity.Where(item => item.value.ToUpper().Contains(search.ToUpper())).Select(item => new SphinxSearchResult
            {
                Id = (int) item.category,
                Ttile = item.value,
                SearchType = "category"
            });
        }
    }
}