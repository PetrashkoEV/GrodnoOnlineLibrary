using System.Data.Entity;
using DigitalResourcesLibrary.SqlContext.Entities;

namespace DigitalResourcesLibrary.SqlContext.Interface.Store
{
    public interface IStoreLocateRepository
    {
        DbSet<storeloc> Entity
        {
            get;
        }
    }
}
