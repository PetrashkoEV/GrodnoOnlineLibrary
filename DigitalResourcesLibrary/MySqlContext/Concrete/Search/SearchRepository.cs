using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MySqlContext.Interface.Search;
using MySqlContext.Model;

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

        public List<SphinxSearchResult> AutoComplite(string searchString)
        {
            var query = "SELECT * " +
                        "FROM SearchRepository " +
                        "WHERE match('*" + searchString + "*') " +
                        "LIMIT " + MaxCountSearch + ";";

            return RunQuery(query);
        }

        public List<SphinxSearchResult> SearchText(string searchString)
        {
            var query = "SELECT * " +
                        "FROM SearchRepository " +
                        "WHERE match('*" + searchString + "*') ";

            return RunQuery(query);
        }

        private List<SphinxSearchResult> RunQuery(string query)
        {
            var result = new List<SphinxSearchResult>();
            using (var connection = new MySqlConnection(ConnectionString))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader.GetInt32("tableId");
                            var resultqueryTitle = reader.GetString("title");
                            var resultqueryDecription = reader.GetString("description");
                            var resultqueryType = reader.GetString("typeTable");
                            result.Add(new SphinxSearchResult
                            {
                                Id = id,
                                Ttile = resultqueryTitle,
                                Decription = resultqueryDecription,
                                TypeDocument = resultqueryType
                            });
                        }
                    }
                }
            }
            return result;
        }
    }
}