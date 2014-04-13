using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySqlContext.Model
{
    public class SphinxSearchResult
    {
        public int Id { get; set; }
        public string Ttile { get; set; }
        public string Decription { get; set; }
        public string TypeDocument { get; set; }
    }
}