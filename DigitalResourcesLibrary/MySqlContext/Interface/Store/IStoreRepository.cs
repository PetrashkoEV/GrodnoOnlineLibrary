using System.Collections.Generic;
using System.Data.Entity;
using MySqlContext.Entities;

namespace MySqlContext.Interface.Store
{
    public interface IStoreRepository
    {
        DbSet<store> Entity
        {
            get;
        }

        store Find(int id);

        IEnumerable<byte[]> FindFile(int id);
    }
}
