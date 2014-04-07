using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalResourcesLibrary.DataContext.Model;
using DigitalResourcesLibrary.DataContext.Model.Article;

namespace DigitalResourcesLibrary.Models
{
    public class SearchViewModel
    {
        public List<ArticleModel> ArticleModels { get; set; }
        public SearchModel SearchModel { get; set; }
    }
}
