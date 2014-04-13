using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalResourcesLibrary.DataContext.Model;

namespace DigitalResourcesLibrary.DataContext.Interfaces
{
    public interface ICategoryService
    {
        /// <summary>
        /// Returns all sub-categories in this category
        /// </summary>
        /// <param name="id">Identificator parent category</param>
        /// <returns>List CategoryModel</returns>
        List<CategoryModel> GetAllSubCategoryById(int id);

        /// <summary>
        /// Getting unique keys of all the subcategories of the selected category
        /// </summary>
        /// <param name="id">Identificator parent category</param>
        /// <returns>List id all subcategory</returns>
        List<long> GetIdAllSybCategory(int id);
    }
}
