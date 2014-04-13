using System.Web.Mvc;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Services;
using DigitalResourcesLibrary.Models;


namespace DigitalResourcesLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService = new ArticleService();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Home/

        public ActionResult About()
        {
            return View(new SearchViewModel());
        }
    }
}
