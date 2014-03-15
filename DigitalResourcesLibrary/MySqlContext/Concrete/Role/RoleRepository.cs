using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using MySqlContext.Entities;
using MySqlContext.Interface.Role;

namespace MySqlContext.Concrete.Role
{
    public class RoleRepository : IRoleRepository
    {
        private LibDbEntities _dataContext = new LibDbEntities();

        public DbSet<role> Entity
        {
            get
            {
                return _dataContext.role;
            }
        }
    }
}
