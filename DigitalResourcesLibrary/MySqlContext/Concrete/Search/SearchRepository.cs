using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MySqlContext.Interface.Search;

namespace MySqlContext.Concrete.Search
{
    public class SearchRepository : ISearchRepository
    {
        private const int MaxCountSearch = 5;

        private string ConnectionString
        {
            get
            {
                var conString = ConfigurationManager.ConnectionStrings["SpxinksLibDb"];
                return conString.ConnectionString;
            }
        }

        public List<string> AutoComplite(string searchString)
        {
            var query = "SELECT id, title " +
                        "FROM SearchRepository " +
                        "WHERE match('@title *" + searchString + "*') " +
                        "LIMIT " + MaxCountSearch + ";";

            var result = new List<string>();
            using (var connection = new MySqlConnection(ConnectionString))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var resultquery = reader.GetString("title");
                            result.Add(resultquery);
                        }
                    }
                }
            }
            return result;
        }
    }
}