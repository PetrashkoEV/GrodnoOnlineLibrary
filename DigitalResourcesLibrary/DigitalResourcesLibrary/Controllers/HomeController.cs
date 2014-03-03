using System.Web.Mvc;
using System.Linq;
using DigitalResourcesLibrary.SqlContext.Concrete.Articles;

namespace DigitalResourcesLibrary.Controllers
{
    public class HomeController : Controller
    {
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
            ArticleLocateRepository repository = new ArticleLocateRepository();
            ViewBag.Content = repository.Entity.FirstOrDefault().content;
            ViewBag.Description = repository.Entity.FirstOrDefault().description;
            ViewBag.TitleArticle = repository.Entity.FirstOrDefault().title;
            return View();
        }
    }
}
