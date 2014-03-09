﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalResourcesLibrary.DataContext.EnumLanguage;

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
                lang = Language.ru.ToString();
            }

            if (lang.Equals(Language.ru.ToString()) || 
                lang.Equals(Language.en.ToString()) ||
                lang.Equals(Language.be.ToString()))
            {
                Session["Culture"] = new CultureInfo(lang);
            }

            return Redirect(returnUrl);
        }

    }
}
