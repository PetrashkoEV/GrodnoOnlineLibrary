using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DigitalResourcesLibrary.SqlContext.Entities;
using DigitalResourcesLibrary.SqlContext.Interface.Role;

namespace DigitalResourcesLibrary.SqlContext.Concrete.Role
{
    public class RoleRepository : IRoleRepository
    {
        private digitalresourceslibraryEntities _dataContext = new digitalresourceslibraryEntities();

        public DbSet<role> Entity
        {
            get
            {
                return _dataContext.role;
            }
        }
    }
}
