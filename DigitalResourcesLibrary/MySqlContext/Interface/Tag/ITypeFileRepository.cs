using System.Collections.Generic;
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

        List<string> GetAllFileType(int curentLocate);

        List<int> GetTypeFileByName(int curentLocate, string name);
    }
}
