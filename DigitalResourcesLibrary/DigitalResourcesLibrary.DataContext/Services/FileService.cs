using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalResourcesLibrary.DataContext.Interfaces;
using MySqlContext.Concrete.Store;
using MySqlContext.Interface.Store;

namespace DigitalResourcesLibrary.DataContext.Services
{
    public class FileService : IFileService
    {
        private readonly IStoreRepository _storeRepository = new StoreRepository();
        
        public byte[] СontentFile(int id)
        {
            return _storeRepository.FindFile(id).FirstOrDefault();
        }
    }
}
