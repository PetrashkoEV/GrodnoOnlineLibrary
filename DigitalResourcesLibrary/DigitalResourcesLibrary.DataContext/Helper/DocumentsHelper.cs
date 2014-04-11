using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalResourcesLibrary.DataContext.Helper
{
    public static class DocumentsHelper
    {
        private static int _count = 10;

        public static int CountNewsOnPage
        {
            get { return _count; } 
            set { _count = value; }
        }
    }
}
