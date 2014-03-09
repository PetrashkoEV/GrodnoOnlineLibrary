using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DigitalResourcesLibrary.DataContext.EnumLanguage;

namespace DigitalResourcesLibrary.DataContext.Model
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public Language Locale { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
