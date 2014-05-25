using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using DigitalResourcesLibrary.DataContext.Enums;
using DigitalResourcesLibrary.DataContext.Helper;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.Models;
using Newtonsoft.Json;

namespace DigitalResourcesLibrary.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IStoreService _storeService;
        private readonly string _nameCookie;

        private string SiteName
        {
            get
            {
                var conString = ConfigurationManager.ConnectionStrings["LibDbSite"];
                return conString.ConnectionString;
            }
        }

        public DocumentsController(IArticleService articleService, IStoreService storeService)
        {
            this._articleService = articleService;
            this._storeService = storeService;
            _nameCookie = "listdocumet";
        }

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
                result.MimeType = store.MimeType;
            }
            else
            {
                result.ValidModel = false;
            }
            ViewBag.SiteName = SiteName;
            return View(result);
        }

        [HttpPost]
        public void AddCookieDocument(int id, TypeDocument type)
        {
            var model = getModel(id, type);

            var cookie = Request.Cookies[_nameCookie];
            List<DocumentLight> result;
            if (cookie == null || cookie.Value == null)
            {
                cookie = new HttpCookie(_nameCookie);
                result = new List<DocumentLight> { model };
            }
            else
            {
                result = JsonConvert.DeserializeObject<List<DocumentLight>>(cookie.Value);
                if (!result.Contains(model))
                {
                    result.Add(model);
                }
            }
            cookie.Value =  JsonConvert.SerializeObject(result);
            HttpContext.Response.Cookies.Add(cookie);
        }

        [HttpPost]
        public void RemoveCookieDocument(int id, TypeDocument type)
        {
            var model = getModel(id, type);

            var cookie = Request.Cookies[_nameCookie];
            if (cookie != null && cookie.Value != null)
            {
                var result = JsonConvert.DeserializeObject<List<DocumentLight>>(cookie.Value);
                result.Remove(model);
                cookie.Value = JsonConvert.SerializeObject(result);
                HttpContext.Response.Cookies.Add(cookie);
            }
        }

        private DocumentLight getModel(int id, TypeDocument type)
        {
            return new DocumentLight (id, type);
        }
    }
}
