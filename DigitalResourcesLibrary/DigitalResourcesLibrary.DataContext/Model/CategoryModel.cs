using System.Collections.Generic;

namespace DigitalResourcesLibrary.DataContext.Model
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CategoryModel> Subcategory { get; set; }
    }
}
