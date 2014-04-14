using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigitalResourcesLibrary.DataContext.Enums;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Model;
using DigitalResourcesLibrary.DataContext.Services;

namespace DigitalResourcesLibrary.Models
{
    public class BaseSearchModel
    {
        private readonly ICategoryService _categoryServices = new CategoryService();
        
        public List<CategoryModel> Categories { get; set; }

        public BaseSearchModel()
        {
            Categories = _categoryServices.GetAllSubCategoryById(1);
        }
    }
}