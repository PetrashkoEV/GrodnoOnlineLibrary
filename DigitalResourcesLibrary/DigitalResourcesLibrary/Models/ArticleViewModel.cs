using System;
using System.Collections.Generic;
using DigitalResourcesLibrary.DataContext.Enums;
using DigitalResourcesLibrary.DataContext.Model;

namespace DigitalResourcesLibrary.Models
{
    public class ArticleViewModel : BaseSearchModel
    {
        public int Id { get; set; }
        public Language Locale { get; set; }
        public string LocateString { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int Visible { get; set; }
        public UserModel User { get; set; }
        public TypeDocument TypeDocument
        {
            get { return TypeDocument.Article; }
        }
        public CategoryModel CategoryDocument { get; set; }
        public List<TagModel> TagDocument { get; set; }
    }
}