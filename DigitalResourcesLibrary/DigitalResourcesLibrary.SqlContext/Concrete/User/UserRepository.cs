using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DigitalResourcesLibrary.SqlContext.Entities;
using DigitalResourcesLibrary.SqlContext.Interface.User;

namespace DigitalResourcesLibrary.SqlContext.Concrete.User
{
    class UserRepository : IUserRepository
    {
        private digitalresourceslibraryEntities _dataContext = new digitalresourceslibraryEntities();

        public DbSet<user> Entity
        {
            get
            {
                return _dataContext.user;
            }
        }
    }
}
