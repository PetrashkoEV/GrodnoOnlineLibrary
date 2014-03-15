using System.Data.Entity;
using MySqlContext.Entities;

namespace MySqlContext.Interface.Categories
{
    public interface ICategoryRepository
    {
        DbSet<category> Entity
        {
            get;
        }
    }
}
