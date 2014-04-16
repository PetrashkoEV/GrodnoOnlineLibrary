using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalResourcesLibrary.DataContext.Enums;
using DigitalResourcesLibrary.DataContext.Helper;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Model;
using DigitalResourcesLibrary.DataContext.Services;
using DigitalResourcesLibrary.Models;

namespace DigitalResourcesLibrary.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchServices _searchServices = new SearchServices();
        private readonly ITagService _tagService = new TagService();

        public ActionResult Index()
        {
            int searchValue = 1;
            int page = 1;
            var result = new SearchViewModel
            {
                Documents = _searchServices.SearchDocumentsByCategory(searchValue, page),
                TypeSearch = TypeSearchDocuments.Category,
                SearchValue = searchValue,
                CountPages = _searchServices.CountPages(),
                VisitedPage = 1
            };
            return View(result);
        }

        [HttpPost]
        public ActionResult Index(SearchViewModel model)
        {
            int page = 1;
            model.Documents = _searchServices.SearchDocumentsByText(model.SearchModel.SearchText, page);
            model.TypeSearch = TypeSearchDocuments.Text;
            model.CountPages = _searchServices.CountPages();
            model.SearchValue = model.SearchModel.SearchText;
            model.VisitedPage = page;
            return View("Index", model);
        }

        public ActionResult SearchByCategory(int searchValue, int page)
        {
            if (page < 1)
                page = 1;

            var result = new SearchViewModel
            {
                Documents = _searchServices.SearchDocumentsByCategory(searchValue, page),
                TypeSearch = TypeSearchDocuments.Category,
                SearchValue = searchValue,
                CountPages = _searchServices.CountPages(),
                VisitedPage = page
            };
            return View("Index", result);
        }

        public ActionResult SearchByDate(DateTime searchValue, int page)
        {
            if (page < 1)
                page = 1;

            var result = new SearchViewModel
            {
                Documents = _searchServices.SearchDocumentsByDate(searchValue, page),
                TypeSearch = TypeSearchDocuments.Date,
                SearchValue = searchValue,
                CountPages = _searchServices.CountPages(),
                VisitedPage = page
            };
            return View("Index", result);
        }

        public ActionResult SearchByText(string searchValue, int page)
        {
            if (page < 1)
                page = 1;

            var result = new SearchViewModel
            {
                Documents = _searchServices.SearchDocumentsByText(searchValue, page),
                TypeSearch = TypeSearchDocuments.Text,
                SearchValue = searchValue,
                CountPages = _searchServices.CountPages(),
                VisitedPage = page
            };
            return View("Index", result);
        }

        public JsonResult AutoComplete(string search)
        {
            var result = _searchServices.AutoComplete(search);
            return Json(new { query = search, suggestions = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AdvancedSearch()
        {
            var model = new AdvancedSearchViewModel
            {
                Tags = _tagService.GetAllTags(),
                FormatDocuments = new List<FileType>
                {
                    FileType.Audio,
                    FileType.Document,
                    FileType.Image,
                    FileType.Other,
                    FileType.Video
                }
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AdvancedSearch(AdvancedSearchViewModel model)
        {
            return View("Index");
        }
    }
}
