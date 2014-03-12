using System.Web.Mvc;
using DigitalResourcesLibrary.DataContext.Services;


namespace DigitalResourcesLibrary.Controllers
{
    public class HomeController : Controller
    {
        private ArticleService articleService = new ArticleService();
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
            var article = articleService.GetArticle();
            return View(article);
        }
    }
}
