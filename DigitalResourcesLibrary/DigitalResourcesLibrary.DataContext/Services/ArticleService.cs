using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DigitalResourcesLibrary.DataContext.Enums;
using DigitalResourcesLibrary.DataContext.Helper;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Model;
using DigitalResourcesLibrary.DataContext.Model.Documents;
using MySqlContext.Concrete.Articles;
using MySqlContext.Interface.Articles;

namespace DigitalResourcesLibrary.DataContext.Services
{
    public class ArticleService: IArticleService
    {
        private readonly Language _curentLocate = LocalizationHelper.GetLocalizationLanguage();
        private readonly IArticleRepository _articleRepository = new ArticleRepository();
        private readonly IArticleLocateRepository _articleLocateRepository = new ArticleLocateRepository();

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

        public List<DocumentModel> FindByCategoryes(List<long> allCategory)
        {
            var articleList = _articleRepository.FindByCategoryes(allCategory);

            var listDocuments = new List<DocumentModel>();
            int curentLocateId = _curentLocate.GetHashCode();
            foreach (var article in articleList)
            {
                var articleLoc = article.articleloc.FirstOrDefault(item => item.locale == curentLocateId);
                if (articleLoc != null)
                {
                    listDocuments.Add(new DocumentModel
                    {
                        Id = article.id,
                        TypeDocument = TypeDocumentsHelper.GeTypeDocument("article"), /*refactor*/
                        ModifiedDate = article.modified.Value,
                        Description = articleLoc.description,
                        Title = articleLoc.title,
                        Locale = _curentLocate,
                        User = new UserModel
                        {
                            Name = article.user.name
                        }
                    });
                }
            }
            return listDocuments;
        }
    
    }
}
