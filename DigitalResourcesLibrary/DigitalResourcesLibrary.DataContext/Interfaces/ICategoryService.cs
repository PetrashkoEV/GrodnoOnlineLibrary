using System.Collections.Generic;
using DigitalResourcesLibrary.DataContext.Model;
using MySqlContext.Model;

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

        /// <summary>
        /// Split a string with categorySelect in a list id
        /// </summary>
        /// <param name="categorySelect">string with category</param>
        /// <returns>list category id</returns>
        List<long> CategorySelectSplit(string categorySelect);

        /// <summary>
        /// Auto Complite search in categoryes
        /// </summary>
        /// <param name="search">Search string</param>
        /// <returns>list Sphinx Search Result</returns>
        List<SphinxSearchResult> AutoComplite(string search);
    }
}
