using System;
using DigitalResourcesLibrary.DataContext.Enums;

namespace DigitalResourcesLibrary.Models
{
    public class DocumentLight : IEquatable<DocumentLight>
    {
        public DocumentLight(int id, TypeDocument typeDocument)
        {
            this.Id = id;
            this.TypeDocument = typeDocument;
        }

        public int Id { get; set; }
        public TypeDocument TypeDocument { get; set; }
        public string Title { get; set; }

        public bool Equals(DocumentLight other)
        {
            if (this.Id == other.Id && this.TypeDocument == other.TypeDocument)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}