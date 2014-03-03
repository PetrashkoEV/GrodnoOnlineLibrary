﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DigitalResourcesLibrary.SqlContext.Entities;

namespace DigitalResourcesLibrary.SqlContext.Concrete.Store
{
    public class StoreLocateRepository
    {
        private digitalresourceslibraryEntities _dataContext = new digitalresourceslibraryEntities();

        public DbSet<storeloc> Entity
        {
            get
            {
                return _dataContext.storeloc;
            }
        }
    }
}
