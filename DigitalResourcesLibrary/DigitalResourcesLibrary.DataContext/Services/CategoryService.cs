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

namespace DigitalResourcesLibrary.DataContext.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly Language _curentLocate = LocalizationHelper.GetLocalizationLanguage();
        private readonly ICategoryRepository _categoryRepository = new CategoryRepository();
        private ICategoryLocateRepository _categoryLocateRepository = new CategoryLocateRepository();

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
    }
}
