using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalResourcesLibrary.DataContext.Helper;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Services;
using DigitalResourcesLibrary.Models;

namespace DigitalResourcesLibrary.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchServices _searchServices = new SearchServices();
        //
        // GET: /Article/

        public ActionResult Index(int id)
        {
            var result = new SearchViewModel
            {
                Documents = _searchServices.SearchDocumentsByCategory(id, 1),
                CountPages = _searchServices.CountPages(),
                VisitedPage = 1
            };
            return View(result);
        }

        [HttpPost]
        public ActionResult Index(SearchViewModel model)
        {
            /*result search*/
            return RedirectToAction("Index");
        }

        public ActionResult Search(int id, int page)
        {
            var result = new SearchViewModel
            {
                Documents = _searchServices.SearchDocumentsByCategory(id, page),
                CountPages = _searchServices.CountPages(),
                VisitedPage = page
            };
            return View(result);
        }

        public JsonResult AutoComplete(string search)
        {
            var result = _searchServices.AutoComplete(search);
            return Json(new { query = search, suggestions = result }, JsonRequestBehavior.AllowGet);
        }

    }
}
