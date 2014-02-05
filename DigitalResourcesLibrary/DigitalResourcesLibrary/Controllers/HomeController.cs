using System.Globalization;
using System.Web.Mvc;
using DigitalResourcesLibrary.Enum;

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
            return View();
        }

        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            if (lang == null)
            {
                lang = Language.RU.ToString();
            }

            if (lang.Equals(Language.RU.ToString()) || lang.Equals(Language.EN.ToString()))
            {
                Session["Culture"] = new CultureInfo(lang);
            }

            return Redirect(returnUrl);
        }
    }
}
