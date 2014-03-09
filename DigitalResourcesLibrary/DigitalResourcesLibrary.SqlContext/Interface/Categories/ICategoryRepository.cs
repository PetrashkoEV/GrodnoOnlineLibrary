using System.Data.Entity;
using DigitalResourcesLibrary.SqlContext.Entities;

namespace DigitalResourcesLibrary.SqlContext.Interface.Categories
{
    public interface ICategoryRepository
    {
        DbSet<category> Entity
        {
            get;
        }
    }
}
