using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using MySqlContext.Entities;
using MySqlContext.Interface.Tag;

namespace MySqlContext.Concrete.Tag
{
    public class TagRepository : ITagRepository
    {
        private LibDbEntities _dataContext = new LibDbEntities();

        public DbSet<tag> Entity
        {
            get
            {
                return _dataContext.tag;
            }
        }

        public tag Find(int id)
        {
            return Entity.Find(id);
        }
    }
}
