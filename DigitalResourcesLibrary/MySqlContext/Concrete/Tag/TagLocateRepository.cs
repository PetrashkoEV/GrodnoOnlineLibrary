using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using MySqlContext.Entities;
using MySqlContext.Interface.Tag;

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
    }
}
