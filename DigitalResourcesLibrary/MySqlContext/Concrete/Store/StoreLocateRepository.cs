using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using MySqlContext.Entities;
using MySqlContext.Interface.Store;
using MySqlContext.Model;

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

        public storeloc GetStoreById(int id, int locateId)
        {
            var model = Entity.FirstOrDefault(item => item.store == id && item.locale == locateId);
            if (model != null && model.type == null)
            {
                var modeltype = Entity.Where(item => item.store == id && item.type != null);
                if (modeltype.Count() != 0)
                {
                    var firstOrDefault = modeltype.FirstOrDefault();
                    if (firstOrDefault != null)
                    {
                        model.type = firstOrDefault.type;
                        model.filename = firstOrDefault.filename;
                    }
                }
            }
            return model;
        }

        public storeloclight GetStoreByIdWithoutData(int id, int locateId)
        {
            var model = Entity.Where(item => item.store == id)
                .Where(item => item.locale == locateId).Select(item => new storeloclight
                {
                    title = item.title,
                    description = item.description,
                    type = item.type,
                    locate = item.locale
                }).FirstOrDefault();

            if (model != null && model.type == null)
            {
                var modeltype = Entity.Where(item => item.store == id && item.type != null);
                if (modeltype.Count() != 0)
                {
                    var firstOrDefault = modeltype.FirstOrDefault();
                    if (firstOrDefault != null) 
                        model.type = firstOrDefault.type;
                }
            }
            return model;
        }
    }
}
