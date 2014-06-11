using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using MySqlContext.Entities;
using MySqlContext.Interface.Tag;

namespace MySqlContext.Concrete.Tag
{
    public class TypeFileRepository : ITypeFileRepository
    {
        private LibDbEntities _dataContext = new LibDbEntities();

        public DbSet<typefile> Entity
        {
            get
            {
                return _dataContext.typefile;
            }
        }

        public List<string> GetAllFileType(int curentLocate)
        {
            return Entity.Where(item => item.locate == curentLocate)
                                    .Select(item => item.Value)
                                    .ToList();
        }

        public List<int> GetTypeFileByName(int curentLocate, string name)
        {
            return Entity.Where(item => item.locate == curentLocate)
                            .Where(item => item.Value == name)
                            .Select(item => item.type).ToList();
        }
    }
}
