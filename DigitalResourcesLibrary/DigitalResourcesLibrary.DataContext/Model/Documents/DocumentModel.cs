using System;
using DigitalResourcesLibrary.DataContext.Enums;

namespace DigitalResourcesLibrary.DataContext.Model.Documents
{
    public class DocumentModel
    {
        public int Id { get; set; }

        public TypeDocument TypeDocument { get; set; }

        public Language Locale { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public DateTime ModifiedDate { get; set; }

        public FileType Type { get; set; }
    }
}
