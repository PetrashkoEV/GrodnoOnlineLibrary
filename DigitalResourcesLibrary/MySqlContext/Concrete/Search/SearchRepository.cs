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

        public List<SphinxSearchResult> AdvancedSearch(List<int> tagId, List<long> categoryId, string searchString)
        {
            var query = "SELECT * " +
                        "FROM SearchRepository WHERE";

            if (searchString !=null && searchString.Count() != 0)
            {
                query += " match('*" + searchString + "*')";
            }
            else
            {
                query += " match('')";
            }

            if (tagId.Count != 0)
            {
                query += " and tagid in (";
                query = tagId.Aggregate(query, (current, tag) => current + (tag + ", "));
                query = query.Remove(query.Count() - 2);
                query += ")";
            }

            if (categoryId != null && categoryId.Count != 0)
            {
                query += " and categoryId in (";
                query = categoryId.Aggregate(query, (current, category) => current + (category + ", "));
                query = query.Remove(query.Count() - 2);
                query += ")";
            }
            query += ";";

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