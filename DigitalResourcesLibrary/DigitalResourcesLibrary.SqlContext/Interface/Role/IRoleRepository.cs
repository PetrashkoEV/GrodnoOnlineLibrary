using System.Data.Entity;
using DigitalResourcesLibrary.SqlContext.Entities;

namespace DigitalResourcesLibrary.SqlContext.Interface.Role
{
    public interface IRoleRepository
    {
        DbSet<role> Entity
        {
            get;
        }
    }
}
