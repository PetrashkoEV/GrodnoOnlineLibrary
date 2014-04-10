using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Services;

namespace DigitalResourcesLibrary.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly IArticleService _articleService = new ArticleService();
        private readonly IStoreService _storeService = new StoreServices();
        //
        // GET: /Documents/Article

        public ActionResult Article(int id)
        {
            var article = _articleService.GetArticleById(id);
            return View(article);
        }

        //
        // GET: /Documents/Store

        public ActionResult Store(int id)
        {
            var store = _storeService.GetStoreById(id);
            return View(store);
        }

    }
}
