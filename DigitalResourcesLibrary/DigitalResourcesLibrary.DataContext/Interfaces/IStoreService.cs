using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalResourcesLibrary.DataContext.Model.Documents;

namespace DigitalResourcesLibrary.DataContext.Interfaces
{
    public interface IStoreService
    {
        StoreModel GetArticleById(int id);
        List<DocumentModel> FindByCategoryes(List<long> allCategory);
    }
}
