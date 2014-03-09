using System.Data.Entity;
using DigitalResourcesLibrary.SqlContext.Entities;

namespace DigitalResourcesLibrary.SqlContext.Interface.Articles
{
    public interface IArticleLocateRepository
    {
        DbSet<articleloc> Entity
        {
            get;
        }
    }
}
