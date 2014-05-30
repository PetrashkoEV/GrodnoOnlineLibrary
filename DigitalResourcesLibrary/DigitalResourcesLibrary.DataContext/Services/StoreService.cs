using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalResourcesLibrary.DataContext.Enums;
using DigitalResourcesLibrary.DataContext.Helper;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Model;
using DigitalResourcesLibrary.DataContext.Model.Documents;
using MySqlContext.Concrete.Store;
using MySqlContext.Entities;
using MySqlContext.Interface.Store;

namespace DigitalResourcesLibrary.DataContext.Services
{
    public class StoreService : IStoreService
    {
        public int CountStore { get; set; }

        private readonly Language _curentLocate = LocalizationHelper.GetLocalizationLanguage();
        private readonly IStoreRepository _storeRepository = new StoreRepository();
        private readonly IStoreLocateRepository _storeLocateRepository = new StoreLocateRepository();

        public StoreModel GetStoreById(int id)
        {
            var item = _storeLocateRepository.GetStoreById(id, _curentLocate.GetHashCode());

            if (item == null)
            {
                return null;
            }

            var result = new StoreModel
            {
                Id = item.store,
                LocaleString = item.locale1.locale1,
                FileName = item.filename,
                MimeType = item.type,
                Title = item.title,
                Description = item.description,
                ModifiedDate = item.store1.modified.Value,
                User = new UserModel
                {
                    Name = item.store1.user.name,
                    Role = new RoleModel {Name = item.store1.user.role.name}
                }
            };
            return result;
        }

        public List<DocumentModel> FindByCategoryes(List<long> allCategory, int page)
        {
            var listStoreAll = _storeRepository.FindByCategoryes(allCategory);
            return CreationArticleToDisplay(listStoreAll);
        }

        public List<DocumentModel> FindByDate(DateTime date, int page)
        {
            var listStoreAll = _storeRepository.FindByDate(date);
            return CreationArticleToDisplay(listStoreAll);
        }

        public List<DocumentModel> FindByStoreId(List<int> articleIds, int page)
        {
            var listStoreAll = _storeRepository.FindByIds(articleIds);
            return CreationArticleToDisplay(listStoreAll);
        }

        public List<DocumentModel> ConverListTagInDocumentModels(IEnumerable<store> storeListAlls)
        {
            return CreationArticleToDisplay(storeListAlls);
        }

        public DocumentModel FindContentStoreById(int id)
        {
            var storeRes = _storeLocateRepository.GetStoreByIdWithoutData(id, _curentLocate.GetHashCode());
            var result = new DocumentModel();
            if (storeRes != null)
            {
                result = new DocumentModel
                {
                    Title = storeRes.title,
                    Description = storeRes.description,
                    Type = FileHelper.GeType(storeRes.type),
                    Locale = (Language)storeRes.locate
                };
            }
            return result;
        }

        /// <summary>
        /// Based storeList formation documents to display the current page
        /// </summary>
        /// <param name="listStoreAll">Full list of Store</param>
        /// <param name="page">Number of page</param>
        /// <returns>List of documents suitable for display on the page</returns>
        private List<DocumentModel> CreationArticleToDisplay(IEnumerable<store> listStoreAll)
        {
            var listDocuments = new List<DocumentModel>();

            // Data is not returned because it will increase the load on the database
            // this step is executed another question
            foreach (var store in listStoreAll)
            {
                var storelocate = FindContentStoreById(store.id);
                if (storelocate.Title != null && storelocate.Description != null)
                {
                    listDocuments.Add(new DocumentModel
                    {
                        Id = store.id,
                        TypeDocument = TypeDocumentsHelper.GeTypeDocument("store"),
                        /*refactor*/
                        ModifiedDate = store.modified.Value,
                        Title = storelocate.Title,
                        Description = storelocate.Description,
                        Locale = _curentLocate,
                        Type = storelocate.Type
                    });
                }
            }
            CountStore = listDocuments.Count(item => item.Locale == _curentLocate);
            return listDocuments;
        }

    }
}
