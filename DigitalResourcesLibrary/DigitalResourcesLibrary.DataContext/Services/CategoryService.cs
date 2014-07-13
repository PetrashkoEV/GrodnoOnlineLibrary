using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalResourcesLibrary.DataContext.Enums;
using DigitalResourcesLibrary.DataContext.Helper;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Model;
using MySqlContext.Concrete.Categories;
using MySqlContext.Interface.Categories;
using MySqlContext.Model;

namespace DigitalResourcesLibrary.DataContext.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly Language _curentLocate;
        private readonly ICategoryRepository _categoryRepository; 
        private readonly ICategoryLocateRepository _categoryLocateRepository; 

        public CategoryService()
        {
            _curentLocate = LocalizationHelper.GetLocalizationLanguage();
            _categoryRepository = new CategoryRepository(); 
            _categoryLocateRepository = new CategoryLocateRepository();
        }

        public List<CategoryModel> GetAllSubCategoryById(int id)
        {
            var result = new List<CategoryModel>();
            var subCategoryesIds = _categoryRepository.GetAllIdSubCategory(id);
            foreach (var subCategoryId in subCategoryesIds)
            {
                result.Add(new CategoryModel
                {
                    Id = (int)subCategoryId,
                    Name = _categoryRepository.GetNameCategoryById((int)subCategoryId, _curentLocate.GetHashCode()),
                    Subcategory = GetAllSubCategoryById((int)subCategoryId)
                });
            }
            return result;
        }

        public List<long> GetIdAllSybCategory(int id)
        {
            var result = new List<long>();
            var subCategoryesIds = _categoryRepository.GetAllIdSubCategory(id);
            result.AddRange(subCategoryesIds);
            foreach (var subCategoryId in subCategoryesIds)
            {
                result.AddRange(GetIdAllSybCategory((int)subCategoryId));
            }
            
            return result;
        }

        public List<long> CategorySelectSplit(string categorySelect)
        {
            var allCategory = GetIdAllSybCategory(1);
            if (string.IsNullOrEmpty(categorySelect))
            {
                return allCategory;
            }
            var splitcategorySelect = categorySelect.Split(';');
            var resultId = new List<long>();
            foreach (var category in splitcategorySelect)
            {
                var categoryId = Convert.ToInt64(category);
                if (allCategory.Contains(categoryId))
                {
                    resultId.Add(categoryId);
                }
            }
            return resultId;
        }

        public List<SphinxSearchResult> AutoComplite(string searchText)
        {
            return _categoryLocateRepository.Search(searchText).ToList();
        }
    }
}
