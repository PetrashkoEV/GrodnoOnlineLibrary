using System.Collections.Generic;

namespace DigitalResourcesLibrary.Models
{
    public class AdvancedSearchViewModel : SearchViewModel
    {
        public List<string> FormatDocuments { get; set; }

        public string TextSearch { get; set; }
        public string TagSelect { get; set; }
        public string FormatDocSelect { get; set; }
        public string CategorySelect { get; set; }
    }
}