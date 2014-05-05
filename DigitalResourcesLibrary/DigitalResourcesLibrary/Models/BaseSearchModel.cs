using System.Collections.Generic;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Model;
using DigitalResourcesLibrary.DataContext.Services;

namespace DigitalResourcesLibrary.Models
{
    public class BaseSearchModel
    {
        private readonly ICategoryService _categoryServices = new CategoryService();
        private readonly ITagService _tagService = new TagService();
        
        public List<CategoryModel> Categories { get; set; }

        public List<TagModel> Tags { get; set; }

        public bool ValidModel { get; set; }

        public BaseSearchModel()
        {
            ValidModel = true;
            Categories = _categoryServices.GetAllSubCategoryById(1);
            Tags = _tagService.GetAllTags();
        }
    }
}