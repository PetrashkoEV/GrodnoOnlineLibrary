using System.Data.Entity;
using DigitalResourcesLibrary.SqlContext.Entities;

namespace DigitalResourcesLibrary.SqlContext.Interface.Tag
{
    public interface ITagRepository
    {
        DbSet<tag> Entity
        {
            get;
        }
    }
}
