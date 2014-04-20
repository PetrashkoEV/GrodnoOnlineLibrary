using System.Web.Mvc;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Services;
using DigitalResourcesLibrary.Models;

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
            var result = new ArticleViewModel
            {
                Id = article.Id,
                Description = article.Description,
                Content = article.Content,
                Title = article.Title,
                Locale = article.Locale,
                ModifiedDate = article.ModifiedDate,
                Visible = article.Visible,
                User = article.User
            };
            return View(result);
        }

        //
        // GET: /Documents/Store

        public ActionResult Store(int id)
        {
            var store = _storeService.GetStoreById(id);
            var result = new StoreViewModel()
            {
                Id = store.Id,
                Description = store.Description,
                Type = store.Type,
                Title = store.Title,
                ModifiedDate = store.ModifiedDate,
                Locale = store.Locale,
                User = store.User,
                Visible = store.Visible,
                FileName = store.FileName
            };
            return View(result);
        }

    }
}
