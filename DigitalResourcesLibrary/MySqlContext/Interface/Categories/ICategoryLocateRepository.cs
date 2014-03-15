using System.Data.Entity;
using MySqlContext.Entities;

namespace MySqlContext.Interface.Categories
{
    public interface ICategoryLocateRepository
    {
        DbSet<categoryloc> Entity
        {
            get;
        }
    }
}
