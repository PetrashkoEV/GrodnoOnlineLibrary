using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DigitalResourcesLibrary.SqlContext.Entities;
using DigitalResourcesLibrary.SqlContext.Interface.Tag;

namespace DigitalResourcesLibrary.SqlContext.Concrete.Tag
{
    public class TagRepository : ITagRepository
    {
        private digitalresourceslibraryEntities _dataContext = new digitalresourceslibraryEntities();

        public DbSet<tag> Entity
        {
            get
            {
                return _dataContext.tag;
            }
        }
    }
}
