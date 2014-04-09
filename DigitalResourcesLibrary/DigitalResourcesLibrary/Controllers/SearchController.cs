using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalResourcesLibrary.DataContext.Helper;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Services;
using DigitalResourcesLibrary.Models;

namespace DigitalResourcesLibrary.Controllers
{
    public class SearchController : Controller
    {
        private readonly IArticleService _articleService = new ArticleService();
        private readonly ISearchServices _searchServices = new SearchServices();
        //
        // GET: /Article/

        public ActionResult Index()
        {
            var result = new SearchViewModel
            {
                /*ArticleModels =
                    _articleService.GetSummaryAllArticle(LocalizationHelper.GetLocalizationLanguage().GetHashCode())*/
            };
            return View(result);
        }

        [HttpPost]
        public ActionResult Index(SearchViewModel model)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Search(int id)
        {
            var result = new SearchViewModel
            {
                Documents = _searchServices.SearchDocumentsByCategory(id)
            };
            return View(result);
        }

        public ActionResult Post(int id)
        {
            var article = _articleService.GetArticleById(id);
            return View(article);
        }

        public JsonResult AutoComplete(string search)
        {
            var result = _searchServices.AutoComplete(search);
            return Json(new { query = search, suggestions = result }, JsonRequestBehavior.AllowGet);
        }

    }
}
