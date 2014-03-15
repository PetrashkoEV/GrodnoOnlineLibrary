using System.Data.Entity;
using MySqlContext.Entities;

namespace MySqlContext.Interface.Role
{
    public interface IRoleRepository
    {
        DbSet<role> Entity
        {
            get;
        }
    }
}
