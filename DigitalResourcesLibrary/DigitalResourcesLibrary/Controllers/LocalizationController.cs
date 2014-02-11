using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalResourcesLibrary.Enum;

namespace DigitalResourcesLibrary.Controllers
{
    public class LocalizationController : Controller
    {
        //
        // GET: /Localization/

        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            if (lang == null)
            {
                lang = Language.RU.ToString();
            }

            if (lang.Equals(Language.RU.ToString()) || 
                lang.Equals(Language.EN.ToString()) ||
                lang.Equals(Language.BE.ToString()))
            {
                Session["Culture"] = new CultureInfo(lang);
            }

            return Redirect(returnUrl);
        }

    }
}
