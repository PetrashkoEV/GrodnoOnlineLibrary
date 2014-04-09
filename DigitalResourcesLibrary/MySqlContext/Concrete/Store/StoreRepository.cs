using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using MySqlContext.Entities;
using MySqlContext.Interface.Store;

namespace MySqlContext.Concrete.Store
{
    public class StoreRepository : IStoreRepository
    {
        private readonly LibDbEntities _dataContext = new LibDbEntities();

        public DbSet<store> Entity
        {
            get
            {
                return _dataContext.store;
            }
        }

        public DbSet<storeloc> EntityStoresLocate
        {
            get
            {
                return _dataContext.storeloc;
            }
        }

        public store Find(int id)
        {
            return Entity.Find(id);
        }

        public IEnumerable<byte[]> FindFile(int id)
        {
            return Entity.Find(id).storeloc.Select(item => item.data);
        }

        public IQueryable<store> FindByCategoryes(List<long> categoryesId)
        {
            var result = Entity.Where(item => categoryesId.Contains(item.category))
                                .Select(item => new store
                                    {
                                        id = item.id,
                                        modified = item.modified,
                                        user = item.user
                                    });
            return result;
        }

        public IQueryable<storeloc> GetStoreLocById(long id, int locateId)
        {
            return EntityStoresLocate.Where(item => item.store == id && item.locale == locateId)
                    .Select(item => new storeloc
                    {
                        store = item.store,
                        locale = locateId,
                        title = item.title,
                        description = item.description
                    });
        }
    }
}