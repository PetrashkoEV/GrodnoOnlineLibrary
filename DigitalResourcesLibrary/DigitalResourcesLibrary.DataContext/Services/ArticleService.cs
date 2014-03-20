using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DigitalResourcesLibrary.DataContext.Helper;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Model;
using DigitalResourcesLibrary.DataContext.Model.Article;
using MySqlContext.Concrete.Articles;
using MySqlContext.Interface.Articles;

namespace DigitalResourcesLibrary.DataContext.Services
{
    public class ArticleService: IArticleService
    {
        private readonly IArticleLocateRepository _articleLocateRepository = new ArticleLocateRepository();

        public List<ArticleModel> GetSummaryAllArticle (int localization)
        {
            var summaryArticle = _articleLocateRepository.Entity
                .Where(item => item.locale == localization)
                .Select(item => new ArticleModel
                {
                    Id = item.article,
                    LocaleString = item.locale1.locale1,
                    Description = item.description,
                    Title = item.title,
                    ModifiedDate = item.article1.modified.Value,
                    User = new UserModel
                        {
                            Name = item.article1.user.name,
                            Role = new RoleModel { Name = item.article1.user.role.name }
                        }
                }).OrderBy(item => item.ModifiedDate);
            return new List<ArticleModel>(summaryArticle);
        }

        public ArticleModel GetArticleById(int id)
        {
            var item = _articleLocateRepository.GetArticleById(id);
            return new ArticleModel
                {
                    Id = item.article,
                    LocaleString = item.locale1.locale1,
                    Content = item.content,
                    Title = item.title,
                    ModifiedDate = item.article1.modified.Value,
                    User = new UserModel
                            {
                                Name = item.article1.user.name,
                                Role = new RoleModel {Name = item.article1.user.role.name}
                            }
                };
        }
    }
}
