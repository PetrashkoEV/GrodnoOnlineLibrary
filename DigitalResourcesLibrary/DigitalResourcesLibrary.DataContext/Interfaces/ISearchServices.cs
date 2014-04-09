using System.Collections.Generic;
using DigitalResourcesLibrary.DataContext.Model.Documents;

namespace DigitalResourcesLibrary.DataContext.Interfaces
{
    public interface ISearchServices
    {
        List<string> AutoComplete(string search);

        List<DocumentModel> SearchDocumentsByCategory(int categoryId);
    }
}