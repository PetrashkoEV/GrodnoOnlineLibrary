using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using MySqlContext.Entities;
using MySqlContext.Interface.Locate;

namespace MySqlContext.Concrete.Locate
{
    public class LocateRepository : ILocateRepository
    {
        private LibDbEntities _dataContext = new LibDbEntities();

        public DbSet<locale> Entity
        {
            get
            {
                return _dataContext.locale;
            }
        }
    }
}
