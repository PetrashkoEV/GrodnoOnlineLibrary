using System.Data.Entity;
using MySqlContext.Entities;

namespace MySqlContext.Interface.Store
{
    public interface IStoreLocateRepository
    {
        DbSet<storeloc> Entity
        {
            get;
        }
    }
}
