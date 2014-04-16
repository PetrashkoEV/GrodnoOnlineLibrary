using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<TagModel> GetAllTags()
        {
            int curentLocateInt = _curentLocate.GetHashCode();
            return _tagLocateRepository.Entity.Where(item => item.locale == curentLocateInt)
                .Select(item => new TagModel
                {
                    Id = item.tag,
                    Name = item.value
                }).ToList();
        } 
    }
}
