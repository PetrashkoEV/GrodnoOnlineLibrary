using System.Collections.Generic;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Services;

namespace DigitalResourcesLibrary.DataContext.Model
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