using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using MySqlContext.Entities;
using MySqlContext.Interface.User;

namespace DigitalResourcesLibrary.SqlContext.Concrete.User
{
    class UserRepository : IUserRepository
    {
        private LibDbEntities _dataContext = new LibDbEntities();

        public DbSet<user> Entity
        {
            get
            {
                return _dataContext.user;
            }
        }
    }
}
