using System.Data.Entity;
using MySqlContext.Entities;

namespace MySqlContext.Interface.Tag
{
    public interface ITagRepository
    {
        DbSet<tag> Entity
        {
            get;
        }

        tag Find(int id);
    }
}
