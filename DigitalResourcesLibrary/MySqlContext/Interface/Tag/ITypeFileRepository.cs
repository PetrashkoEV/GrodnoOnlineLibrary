using System.Data.Entity;
using MySqlContext.Entities;

namespace MySqlContext.Interface.Tag
{
    public interface ITypeFileRepository
    {
        DbSet<typefile> Entity
        {
            get;
        }
    }
}
