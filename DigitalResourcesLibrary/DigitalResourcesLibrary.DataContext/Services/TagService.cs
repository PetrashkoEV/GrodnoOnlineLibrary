using System.Collections.Generic;
using System.Linq;
using DigitalResourcesLibrary.DataContext.Enums;
using DigitalResourcesLibrary.DataContext.Helper;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Model;
using MySqlContext.Concrete.Tag;
using MySqlContext.Interface.Tag;

namespace DigitalResourcesLibrary.DataContext.Services
{
    public class TagService : ITagService
    {
        private readonly Language _curentLocate = LocalizationHelper.GetLocalizationLanguage();
        private ITagRepository _tagRepository = new TagRepository();
        private readonly ITagLocateRepository _tagLocateRepository = new TagLocateRepository();
        private readonly ITypeFileRepository _typeFileRepository = new TypeFileRepository();

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
            var curentLocateInt = _curentLocate.GetHashCode();
            return _typeFileRepository.Entity.Where(item => item.locate == curentLocateInt)
                                    .Select(item => item.Value)
                                    .ToList();
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
            var curentLocateInt = _curentLocate.GetHashCode();
            var fullListFileDocuments = _typeFileRepository.Entity.Where(item => item.locate == curentLocateInt)
                                    .ToList();

            var splitFileDocuments = fileDocumentsSelect.Split(';');
            var resultId = new List<int>();
            foreach (var fileDoc in splitFileDocuments)
            {
                resultId.AddRange(fullListFileDocuments.Where(item => item.Value == fileDoc).Select(item => item.type));
            }

            return resultId.Select(FileHelper.GeType).ToList();
        }
    }
}
