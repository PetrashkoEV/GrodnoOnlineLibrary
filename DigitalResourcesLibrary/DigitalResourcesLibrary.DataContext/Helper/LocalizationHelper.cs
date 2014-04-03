using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using DigitalResourcesLibrary.DataContext.Enums;

namespace DigitalResourcesLibrary.DataContext.Helper
{
    public static class LocalizationHelper
    {
        /// <summary>
        /// Get the current language of the site.
        /// </summary>
        public static Language GetLocalizationLanguage()
        {
            return (Language)Enum.Parse(typeof(Language), CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
        }

        /// <summary>
        /// Convert string language in Language Enum
        /// </summary>
        /// <param name="language">Text language name</param>
        /// <returns>Language Enum</returns>
        public static Language ConvertStringInLanguage(string language)
        {
            return (Language)Enum.Parse(typeof(Language), language); 
        }

        /// <summary>
        /// Getting integer value Language
        /// </summary>
        /// <param name="language">Language Enum</param>
        /// <returns>Integer value Language Enum</returns>
        public static int GetLanguageValue(Language language)
        {
            return language.GetHashCode();
        }
    }
}
