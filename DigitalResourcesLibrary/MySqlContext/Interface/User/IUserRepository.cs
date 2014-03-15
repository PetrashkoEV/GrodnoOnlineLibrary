using System.Data.Entity;
using MySqlContext.Entities;

namespace MySqlContext.Interface.User
{
    public interface IUserRepository
    {
        DbSet<user> Entity
        {
            get;
        }
    }
}
