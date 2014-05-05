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
            var result = new ArticleViewModel();
            if (article != null)
            {
                result.Id = article.Id;
                result.Description = article.Description;
                result.Content = article.Content;
                result.Title = article.Title;
                result.Locale = article.Locale;
                result.ModifiedDate = article.ModifiedDate;
                result.Visible = article.Visible;
                result.User = article.User;
            }
            else
            {
                result.ValidModel = false;
            }

            return View(result);
        }

        //
        // GET: /Documents/Store

        public ActionResult Store(int id)
        {
            var store = _storeService.GetStoreById(id);
            var result = new StoreViewModel();
            if (store != null)
            {
                result.Id = store.Id;
                result.Description = store.Description;
                result.Type = store.Type;
                result.Title = store.Title;
                result.ModifiedDate = store.ModifiedDate;
                result.Locale = store.Locale;
                result.User = store.User;
                result.Visible = store.Visible;
                result.FileName = store.FileName;
            }
            else
            {
                result.ValidModel = false;
            }
            return View(result);
        }

    }
}
