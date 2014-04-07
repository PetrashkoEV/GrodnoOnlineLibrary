using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlContext.Interface.Search
{
    public interface ISearchRepository
    {
        List<string> AutoComplite(string searchString);
    }
}
