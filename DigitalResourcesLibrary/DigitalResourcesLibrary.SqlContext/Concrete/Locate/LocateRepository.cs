using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DigitalResourcesLibrary.SqlContext.Entities;
using DigitalResourcesLibrary.SqlContext.Interface.Locate;

namespace DigitalResourcesLibrary.SqlContext.Concrete.Locate
{
    public class LocateRepository : ILocateRepository
    {
        private digitalresourceslibraryEntities _dataContext = new digitalresourceslibraryEntities();

        public DbSet<locale> Entity
        {
            get
            {
                return _dataContext.locale;
            }
        }
    }
}
