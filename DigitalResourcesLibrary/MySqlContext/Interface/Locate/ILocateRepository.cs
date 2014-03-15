using System.Data.Entity;
using MySqlContext.Entities;

namespace MySqlContext.Interface.Locate
{
    public interface ILocateRepository
    {
        DbSet<locale> Entity
        {
            get;
        }
    }
}
