using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalResourcesLibrary.DataContext.Helper;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Services;

namespace DigitalResourcesLibrary.Controllers
{
    public class SearchController : Controller
    {
        private IArticleService _articleService = new ArticleService();
        //
        // GET: /Article/

        public ActionResult Index()
        {
            var articles = _articleService.GetSummaryAllArticle(LocalizationHelper.GetLocalizationLanguage().GetHashCode());
            return View(articles);
        }

        public ActionResult Post(int id)
        {
            var article = _articleService.GetArticleById(id);
            return View(article);
        }

    }
}
