using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalResourcesLibrary.DataContext.Model;
using DigitalResourcesLibrary.DataContext.Model.Documents;

namespace DigitalResourcesLibrary.Models
{
    public class SearchViewModel
    {
        public List<DocumentModel> Documents { get; set; }
        public SearchModel SearchModel { get; set; }
    }
}
