using System.Web.UI.WebControls.Expressions;

namespace MySqlContext.Model
{
    public class SphinxSearchResult
    {
        public int Id { get; set; }
        public string Ttile { get; set; }
        public string Decription { get; set; }
        public string TypeDocument { get; set; }
        public string SearchType { get; set; }
    }
}