using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using MySqlContext.Entities;
using MySqlContext.Interface.Store;

namespace MySqlContext.Concrete.Store
{
    public class StoreRepository : IStoreRepository
    {
        private LibDbEntities _dataContext = new LibDbEntities();

        public DbSet<store> Entity
        {
            get
            {
                return _dataContext.store;
            }
        }
    }
}
