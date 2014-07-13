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
        private const int MaxCountSearchDocuments = 1000;

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
                        "WHERE match('" + ReplaseSearchText(searchString) + "') " +
                        "LIMIT " + MaxCountSearch + ";";

            return RunQuery(query);
        }

        public List<SphinxSearchResult> SearchText(string searchString)
        {
            var query = "SELECT * " +
                        "FROM SearchRepository " +
                        "WHERE match('" + ReplaseSearchText(searchString) + "') " +
                        "LIMIT " + MaxCountSearchDocuments + ";";

            return RunQuery(query);
        }

        public List<SphinxSearchResult> AdvancedSearch(List<int> tagId, List<long> categoryId, string searchString)
        {
            var query = "SELECT * " +
                        "FROM SearchRepository WHERE";

            query += " match('" + ReplaseSearchText(searchString) + "')";

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

            query += "LIMIT " + MaxCountSearchDocuments + ";";

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

                    try
                    {
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
                    catch (Exception)
                    {
                        return new List<SphinxSearchResult>();
                    }
                }
            }
            return result;
        }

        private string ReplaseSearchText(string searchString)
        {
            if (searchString == null || !searchString.Any())
                return "";

            var result = "*" + searchString;
            result = result.Replace("(", " * ").Replace(")", " * ");
            result = result.Replace(";", " * ");
            result = result.Replace("'", " * ");
            result = result.Replace("-", " * ");
            result = result.Replace(":", " * ");
            result = result.Replace("?", " * ");
            result = result.Replace("^", " * ");
            result = result.Replace("%", " * ");
            result = result.Replace("$", " * ");
            result = result.Replace("#", " * ");
            result = result.Replace("@", " * ");
            result = result.Replace("!", " * ");
            result = result.Replace("~", " * ");
            result = result.Replace("[", " * ").Replace("]", " * ");
            result = result.Replace("{", " * ").Replace("}", " * ");
            result = result.Replace("<", " * ").Replace(">", " * ");
            result = result.Replace("/", " * ").Replace("+", " * ");
            result = result.Replace('"'.ToString(), " * ");
            return result + "*";
        }
    }
}