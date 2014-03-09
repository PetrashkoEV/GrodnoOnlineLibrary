using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DigitalResourcesLibrary.SqlContext.Entities;
using DigitalResourcesLibrary.SqlContext.Interface.Store;

namespace DigitalResourcesLibrary.SqlContext.Concrete.Store
{
    public class StoreRepository : IStoreRepository
    {
        private digitalresourceslibraryEntities _dataContext = new digitalresourceslibraryEntities();

        public DbSet<store> Entity
        {
            get
            {
                return _dataContext.store;
            }
        }
    }
}
