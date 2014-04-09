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
using MySqlContext.Interface.Store;

namespace DigitalResourcesLibrary.DataContext.Services
{
    public class StoreServices : IStoreService
    {
        private readonly Language _curentLocate = LocalizationHelper.GetLocalizationLanguage();
        private readonly IStoreRepository _storeRepository = new StoreRepository();
        private readonly IStoreLocateRepository _storeLocateRepository = new StoreLocateRepository();

        public StoreModel GetArticleById(int id)
        {
            var item = _storeLocateRepository.GetArticleById(id);
            return new StoreModel
            {
                Id = item.store,
                LocaleString = item.locale1.locale1,
                FileName = item.filename,
                Type = item.type,
                Title = item.title,
                ModifiedDate = item.store1.modified.Value,
                User = new UserModel
                {
                    Name = item.store1.user.name,
                    Role = new RoleModel { Name = item.store1.user.role.name }
                }
            };
        }

        public List<DocumentModel> FindByCategoryes(List<long> allCategory)
        {
            var listStore = _storeRepository.FindByCategoryes(allCategory);

            var listDocuments = new List<DocumentModel>();

            // Data is not returned because it will increase the load on the database
            // this step is executed another question
            foreach (var store in listStore)
            {
                var storeloc = store.storeloc.FirstOrDefault();
                if (storeloc != null)
                {
                    listDocuments.Add(new DocumentModel
                    {
                        Id = store.id,
                        TypeDocument = TypeDocumentsHelper.GeTypeDocument("store"),
                        ModifiedDate = store.modified.Value,
                        User = new UserModel
                        {
                            Name = store.user.name
                        }
                    });
                }
            }
            return listDocuments; 
        }
    }
}
