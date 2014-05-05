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
using MySqlContext.Entities;
using MySqlContext.Interface.Articles;

namespace DigitalResourcesLibrary.DataContext.Services
{
    public class ArticleService: IArticleService
    {
        public int CountArticle { get; set; }
        private readonly Language _curentLocate = LocalizationHelper.GetLocalizationLanguage();
        private readonly IArticleRepository _articleRepository = new ArticleRepository();
        private readonly IArticleLocateRepository _articleLocateRepository = new ArticleLocateRepository();

        private readonly int _countNewsOnPage = DocumentsHelper.CountNewsOnPage;

        public ArticleModel GetArticleById(int id)
        {
            var item = _articleLocateRepository.GetArticleById(id, _curentLocate.GetHashCode());
            if (item == null)
            {
                return null;
            }
            return new ArticleModel
                {
                    Id = item.article,
                    LocateString = item.locale1.locale1,
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

        public List<DocumentModel> FindByCategoryes(List<long> allCategory, int page)
        {
            var articleListAll = _articleRepository.FindByCategoryes(allCategory);
            return CreationArticleToDisplay(articleListAll);
        }

        public List<DocumentModel> FindByDate(DateTime date, int page)
        {
            var articleListAll = _articleRepository.FindByDate(date);
            return CreationArticleToDisplay(articleListAll);
        }

        public List<DocumentModel> FindByArticleId(List<int> articleIds, int page)
        {
            var articleListAll = _articleRepository.FindByIds(articleIds);
            return CreationArticleToDisplay(articleListAll);
        }

        public List<DocumentModel> ConverListTagInDocumentModels(IEnumerable<article> articleListAlls)
        {
            return CreationArticleToDisplay(articleListAlls);
        }

        /// <summary>
        /// Based articleList formation documents to display the current page
        /// </summary>
        /// <param name="articleListAll">Full list of articles</param>
        /// <returns>List of documents suitable for display on the page</returns>
        private List<DocumentModel> CreationArticleToDisplay(IEnumerable<article> articleListAll)
        {
            var listDocuments = new List<DocumentModel>();
            int curentLocateId = _curentLocate.GetHashCode();
            foreach (var article in articleListAll)
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
                        Type = FileType.Document
                    });
                }
            }
            CountArticle = listDocuments.Count();
            return listDocuments;
        } 
    }
}
