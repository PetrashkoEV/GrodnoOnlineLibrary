﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DigitalResourcesLibrary.SqlContext.Entities;
using DigitalResourcesLibrary.SqlContext.Interface.Categories;

namespace DigitalResourcesLibrary.SqlContext.Concrete.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private digitalresourceslibraryEntities _dataContext = new digitalresourceslibraryEntities();

        public DbSet<category> Entity
        {
            get
            {
                return _dataContext.category;
            }
        }
    }
}