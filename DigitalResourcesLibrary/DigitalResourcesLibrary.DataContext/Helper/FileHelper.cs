using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalResourcesLibrary.DataContext.Enums;

namespace DigitalResourcesLibrary.DataContext.Helper
{
    public static class FileHelper
    {
        /// <summary>
        /// Get File type by name 
        /// </summary>
        /// <param name="type">Name type file</param>
        /// <returns>File model</returns>
        public static FileType GeType(string type)
        {
            switch (type)
            {
                case "application/pdf":
                    return FileType.Document;
                case "audio/mpeg3":
                    return FileType.Audio;
                case "image/jpeg":
                    return FileType.Image;
                case "video/mp4":
                    return FileType.Video;
            }
            return FileType.SelectAll;
        }

        /// <summary>
        /// Get name type by FileType model
        /// </summary>
        /// <param name="type">FileType model</param>
        /// <returns>name type</returns>
        public static string GeType(FileType type)
        {
            switch (type)
            {
                case FileType.Document:
                    return "application/pdf";
                case FileType.Audio:
                    return "audio/mpeg";
                case FileType.Image:
                    return "image/jpeg";
                case FileType.Video:
                    return "video/mp4";
            }
            return "other";
        }

        /// <summary>
        /// Get type by value
        /// </summary>
        /// <param name="id">Value model</param>
        /// <returns>File model</returns>
        public static FileType GeType(int id)
        {
            return (FileType) id;
        }
    }
}
