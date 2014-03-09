using System.Data.Entity;
using DigitalResourcesLibrary.SqlContext.Entities;

namespace DigitalResourcesLibrary.SqlContext.Interface.Locate
{
    public interface ILocateRepository
    {
        DbSet<locale> Entity
        {
            get;
        }
    }
}
