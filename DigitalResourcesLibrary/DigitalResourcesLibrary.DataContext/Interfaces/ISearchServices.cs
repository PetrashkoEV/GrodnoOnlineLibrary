using System.Collections.Generic;

namespace DigitalResourcesLibrary.DataContext.Interfaces
{
    public interface ISearchServices
    {
        List<string> AutoComplete(string search);
    }
}