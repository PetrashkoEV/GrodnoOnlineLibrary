using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalResourcesLibrary.DataContext.Model;
using DigitalResourcesLibrary.DataContext.Model.Documents;

namespace DigitalResourcesLibrary.DataContext.Interfaces
{
    public interface ITagService
    {
        /// <summary>
        /// Get all list tags of Db
        /// </summary>
        /// <returns>list TagModel</returns>
        List<TagModel> GetAllTags();
    }
}
