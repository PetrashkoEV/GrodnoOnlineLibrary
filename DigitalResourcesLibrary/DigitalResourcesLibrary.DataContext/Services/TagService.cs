using System.Collections.Generic;
using System.Linq;
using DigitalResourcesLibrary.DataContext.Enums;
using DigitalResourcesLibrary.DataContext.Helper;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Model;
using MySqlContext.Concrete.Tag;
using MySqlContext.Interface.Tag;
using MySqlContext.Model;

namespace DigitalResourcesLibrary.DataContext.Services
{
    public class TagService : ITagService
    {
        private readonly Language _curentLocate = LocalizationHelper.GetLocalizationLanguage();
        private readonly ITagLocateRepository _tagLocateRepository;
        private readonly ITypeFileRepository _typeFileRepository;

        public TagService()
        {
            _tagLocateRepository = new TagLocateRepository();
            _typeFileRepository = new TypeFileRepository();
        }

        public List<TagModel> GetAllTags()
        {
            var curentLocateInt = _curentLocate.GetHashCode();
            return _tagLocateRepository.Entity.Where(item => item.locale == curentLocateInt)
                .Select(item => new TagModel
                {
                    Id = item.tag,
                    Name = item.value
                }).ToList();
        }

        public List<string> GetAllFileType()
        {
            return _typeFileRepository.GetAllFileType(_curentLocate.GetHashCode());
        }

        public List<TagModel> TagSelectSplit(string tagSelect)
        {
            var splitTag = tagSelect.Split(';');
            var fullListTags = GetAllTags();
            var result = new List<TagModel>();

            foreach (var tag in splitTag)
            {
               result.AddRange(fullListTags.Where(item => item.Name == tag).Select(item => new TagModel
                                   {
                                       Id = item.Id,
                                       Name = item.Name
                                   }));
            }
            return result;
        }

        public List<FileType> FileTypeSplit(string fileDocumentsSelect)
        {
            var splitFileDocuments = fileDocumentsSelect.Split(';');
            var result = new List<FileType>();
            foreach (var fileDoc in splitFileDocuments)
            {
                var type = _typeFileRepository.GetTypeFileByName(_curentLocate.GetHashCode(), fileDoc)
                        .Select(FileHelper.GeType);
                result.AddRange(type);
            }

            return result;
        }

        public List<SphinxSearchResult> AutoComplite(string searchText)
        {
            return _tagLocateRepository.Search(searchText).ToList();
        }
    }
}
