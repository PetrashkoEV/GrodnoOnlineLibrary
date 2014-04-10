using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using MySqlContext.Entities;
using MySqlContext.Interface.Store;

namespace MySqlContext.Concrete.Store
{
    public class StoreLocateRepository : IStoreLocateRepository
    {
        private LibDbEntities _dataContext = new LibDbEntities();

        public DbSet<storeloc> Entity
        {
            get
            {
                return _dataContext.storeloc;
            }
        }

        public storeloc GetStoreById(int id)
        {
            return Entity.FirstOrDefault(item => item.store == id);
        }

        public storeloclight GetStoreByIdWithoutData(int id, int locateId)
        {
            return Entity.Where(item => item.store == id && item.locale == locateId).Select(item => new storeloclight
            {
                title = item.title,
                description = item.description
            }).FirstOrDefault();
        }
    }
}
