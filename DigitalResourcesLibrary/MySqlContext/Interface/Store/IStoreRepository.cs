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
    }
}
