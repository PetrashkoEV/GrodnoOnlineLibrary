using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DigitalResourcesLibrary.DataContext.Enums;
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
        public string AddCookieDocument(int id, TypeDocument type)
        {
            var model = new DocumentLight(id, type);

            var cookie = Request.Cookies[_nameCookie];
            List<DocumentLight> resultCookie;
            if (cookie == null || cookie.Value == null) // cookie is not created
            {
                cookie = new HttpCookie(_nameCookie);
                cookie.Expires.AddDays(365);
                resultCookie = new List<DocumentLight> { model };
            }
            else
            {
                resultCookie = JsonConvert.DeserializeObject<List<DocumentLight>>(cookie.Value);
                if (!resultCookie.Contains(model))
                {
                    resultCookie.Add(model);
                }
                else
                {
                    model = null;
                }
            }
            cookie.Value = JsonConvert.SerializeObject(resultCookie);
            HttpContext.Response.ContentEncoding = Encoding.GetEncoding(1251);
            HttpContext.Response.Cookies.Add(cookie);

            if (model != null)
            {
                model.Title = GetTitle(model.Id, model.TypeDocument);
            }
            return JsonConvert.SerializeObject(model);
        }

        [HttpPost]
        public string RemoveCookieDocument(int id, TypeDocument type)
        {
            var model = new DocumentLight(id, type);

            var cookie = Request.Cookies[_nameCookie];
            if (cookie != null && cookie.Value != null)
            {
                var result = JsonConvert.DeserializeObject<List<DocumentLight>>(cookie.Value);
                result.Remove(model);
                cookie.Value = JsonConvert.SerializeObject(result);
                HttpContext.Response.Cookies.Add(cookie);
                return JsonConvert.SerializeObject(model);
            }
            return JsonConvert.SerializeObject(null);
        }

        [HttpPost]
        public string GetTitleDookmarks()
        {
            var cookie = Request.Cookies[_nameCookie];
            var result = new List<DocumentLight>();
            if (cookie != null && cookie.Value != null)
            {
                result = JsonConvert.DeserializeObject<List<DocumentLight>>(cookie.Value);
                foreach (var light in result)
                {
                    light.Title = GetTitle(light.Id, light.TypeDocument);
                }
            }
            return JsonConvert.SerializeObject(result);
        }

        private string GetTitle(int id, TypeDocument type)
        {
            return type == TypeDocument.Article
                                ? _articleService.GetArticleById(id).Title
                                : _storeService.GetStoreById(id).Title;
        }
    }
}
