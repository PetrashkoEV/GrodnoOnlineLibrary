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

        public store Find(int id)
        {
            return Entity.Find(id);
        }

        public IEnumerable<byte[]> FindFile(int id, int locateId)
        {
            return Entity.Find(id).storeloc.Where(item=> item.locale == locateId).Select(item => item.data);
        }

        public IQueryable<store> FindByCategoryes(List<long> categoryesId)
        {
            var result = Entity.Where(item => categoryesId.Contains(item.category));
            return result;
        }

        public IQueryable<store> FindByDate(DateTime date)
        {
            var result = Entity.Where(item => item.modified.Value.Year == date.Year && item.modified.Value.Month == date.Month);
            return result;
        }

        public IQueryable<store> FindByIds(List<int> articleIds)
        {
            var result = Entity.Where(item => articleIds.Contains(item.id));
            return result;
        }
    }
}