using System.Collections.Generic;
using DigitalResourcesLibrary.DataContext.Enums;
using DigitalResourcesLibrary.DataContext.Model;
using DigitalResourcesLibrary.DataContext.Model.Documents;

namespace DigitalResourcesLibrary.Models
{
    public class SearchViewModel : BaseSearchModel
    {
        public List<DocumentModel> Documents { get; set; }
        public SearchModel SearchModel { get; set; }
        
        
        public int CountPages { get; set; }
        public int VisitedPage { get; set; }
        public TypeSearchDocuments TypeSearch { get; set; }
        public object SearchValue { get; set; }
    }
}
