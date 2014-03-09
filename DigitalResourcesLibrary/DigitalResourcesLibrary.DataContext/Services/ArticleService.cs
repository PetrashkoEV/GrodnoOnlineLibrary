using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DigitalResourcesLibrary.DataContext.Helper;
using DigitalResourcesLibrary.DataContext.Model;
using DigitalResourcesLibrary.SqlContext.Concrete.Articles;
using DigitalResourcesLibrary.SqlContext.Interface.Articles;

namespace DigitalResourcesLibrary.DataContext.Services
{
    public class ArticleService
    {
        public ArticleModel GetArticle()
        {
            IArticleLocateRepository articleLocateRepository = new ArticleLocateRepository();
            var article = articleLocateRepository.Entity.FirstOrDefault();
            return new ArticleModel
                {
                    Content = article.content,
                    Description = article.description,
                    Id = article.article,
                    Title = article.title
                };
        }
    }
}
