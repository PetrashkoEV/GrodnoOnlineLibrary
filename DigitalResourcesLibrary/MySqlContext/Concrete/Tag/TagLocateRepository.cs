using System;
using System.Data.Entity;
using System.Linq;
using MySqlContext.Entities;
using MySqlContext.Interface.Tag;
using MySqlContext.Model;

namespace MySqlContext.Concrete.Tag
{
    public class TagLocateRepository : ITagLocateRepository
    {
        private LibDbEntities _dataContext = new LibDbEntities();

        public DbSet<tagloc> Entity
        {
            get
            {
                return _dataContext.tagloc;
            }
        }

        public IQueryable<SphinxSearchResult> Search(string search)
        {
            return Entity.Where(item => item.value.ToUpper().Contains(search.ToUpper())).Select(item => new SphinxSearchResult
            {
                Id = item.tag,
                Ttile = item.value,
                SearchType = "tag"
            });
        }
    }
}
