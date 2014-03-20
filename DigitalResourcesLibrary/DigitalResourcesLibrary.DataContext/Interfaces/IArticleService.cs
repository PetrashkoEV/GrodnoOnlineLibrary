using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalResourcesLibrary.DataContext.Model.Article;

namespace DigitalResourcesLibrary.DataContext.Interfaces
{
    public interface IArticleService
    {
        List<ArticleModel> GetSummaryAllArticle(int localization);
        ArticleModel GetArticleById(int id);
    }
}
