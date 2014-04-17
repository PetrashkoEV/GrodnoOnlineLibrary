using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigitalResourcesLibrary.DataContext.Enums;
using DigitalResourcesLibrary.DataContext.Model;

namespace DigitalResourcesLibrary.Models
{
    public class AdvancedSearchViewModel : BaseSearchModel
    {
        public string TextSearch { get; set; }

        public List<TagModel> Tags { get; set; }

        public List<FileType> FormatDocuments { get; set; }

        public string TagSelect { get; set; }

        public string FormatDocSelect { get; set; }
    }
}