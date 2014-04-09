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
        private LibDbEntities _dataContext = new LibDbEntities();
        private IStoreLocateRepository _storeLocateRepository = new StoreLocateRepository();

        public DbSet<store> Entity
        {
            get
            {
                return _dataContext.store;
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

        public IQueryable<store> FindByCategoryes(List<long> categoryesId, int locateId)
        {
            var result = Entity.Where(item => categoryesId.Contains(item.category))
                                .OrderBy(item => item.modified)
                                .Select(item => new store
                                    {
                                        id = item.id,
                                        modified = item.modified,
                                        user = item.user,
                                        storeloc = (List<storeloc>)_storeLocateRepository.Entity.Where(storeitem => storeitem.store == item.id && storeitem.locale == locateId)
                                                                                         .Select(storeitem => new storeloc
                                                                                         {
                                                                                             store = storeitem.store,
                                                                                             locale = locateId,
                                                                                             title = storeitem.title,
                                                                                             description = storeitem.description
                                                                                         })
                                    });
            return result;
        }
    }
}