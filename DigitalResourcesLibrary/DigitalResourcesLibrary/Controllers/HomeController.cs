using System.Data.SqlClient;
using System.Web.Mvc;
using System.Linq;
using DigitalResourcesLibrary.DataContext.EnumLanguage;
using DigitalResourcesLibrary.DataContext.Helper;
using DigitalResourcesLibrary.DataContext.Model;
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
            /*ArticleLocateRepository repository = new ArticleLocateRepository();
            ViewBag.Content = repository.Entity.FirstOrDefault().content;
            ViewBag.Description = repository.Entity.FirstOrDefault().description;
            ViewBag.TitleArticle = repository.Entity.FirstOrDefault().title;*/
            var article = articleService.GetArticle();
            return View(new ArticleModel());
        }
    }
}
