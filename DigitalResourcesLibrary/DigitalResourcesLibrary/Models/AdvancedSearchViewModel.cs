using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigitalResourcesLibrary.DataContext.Enums;
using DigitalResourcesLibrary.DataContext.Model;
using DigitalResourcesLibrary.DataContext.Model.Documents;

namespace DigitalResourcesLibrary.Models
{
    public class AdvancedSearchViewModel : SearchViewModel
    {
        public List<string> FormatDocuments { get; set; }

        public string TextSearch { get; set; }
        public string TagSelect { get; set; }
        public string FormatDocSelect { get; set; }
    }
}