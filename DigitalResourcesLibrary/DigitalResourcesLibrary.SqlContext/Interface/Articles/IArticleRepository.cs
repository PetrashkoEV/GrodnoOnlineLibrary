using System.Data.Entity;
using DigitalResourcesLibrary.SqlContext.Entities;

namespace DigitalResourcesLibrary.SqlContext.Interface.Articles
{
    public interface IArticleRepository
    {
        DbSet<article> Entity
        {
            get;
        }
    }
}
