using System.Web.Mvc;
using DigitalResourcesLibrary.Models;


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
            return View(new SearchViewModel());
        }
    }
}
