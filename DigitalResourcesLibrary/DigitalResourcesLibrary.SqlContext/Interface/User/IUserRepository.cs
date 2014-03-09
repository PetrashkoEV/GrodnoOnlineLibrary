using System.Data.Entity;
using DigitalResourcesLibrary.SqlContext.Entities;

namespace DigitalResourcesLibrary.SqlContext.Interface.User
{
    public interface IUserRepository
    {
        DbSet<user> Entity
        {
            get;
        }
    }
}
