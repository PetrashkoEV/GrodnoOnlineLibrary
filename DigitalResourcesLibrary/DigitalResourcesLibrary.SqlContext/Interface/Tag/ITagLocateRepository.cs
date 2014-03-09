using System.Data.Entity;
using DigitalResourcesLibrary.SqlContext.Entities;

namespace DigitalResourcesLibrary.SqlContext.Interface.Tag
{
    public interface ITagLocateRepository
    {
        DbSet<tagloc> Entity
        {
            get;
        }
    }
}
