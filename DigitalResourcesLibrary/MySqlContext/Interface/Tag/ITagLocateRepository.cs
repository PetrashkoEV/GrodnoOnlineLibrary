using System.Data.Entity;
using MySqlContext.Entities;

namespace MySqlContext.Interface.Tag
{
    public interface ITagLocateRepository
    {
        DbSet<tagloc> Entity
        {
            get;
        }
    }
}
