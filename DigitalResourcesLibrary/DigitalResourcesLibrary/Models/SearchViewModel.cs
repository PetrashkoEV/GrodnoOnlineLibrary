using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Model;
using DigitalResourcesLibrary.DataContext.Model.Documents;
using DigitalResourcesLibrary.DataContext.Services;

namespace DigitalResourcesLibrary.Models
{
    public class SearchViewModel
    {
        private readonly ICategoryService _categoryServices = new CategoryService();

        public List<DocumentModel> Documents { get; set; }
        public SearchModel SearchModel { get; set; }
        public int CountPages { get; set; }
        public int VisitedPage { get; set; }

        public List<CategoryModel> Categories { get; set; }

        public SearchViewModel()
        {
            Categories = _categoryServices.GetAllSubCategoryById(1);
        }
    }
}
