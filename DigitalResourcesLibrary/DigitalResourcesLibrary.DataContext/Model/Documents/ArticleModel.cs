using System;
using DigitalResourcesLibrary.DataContext.Enums;

namespace DigitalResourcesLibrary.DataContext.Model.Documents
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public Language Locale { get; set; }
        public string LocaleString { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int Visible { get; set; }
        public UserModel User { get; set; }
    }
}
