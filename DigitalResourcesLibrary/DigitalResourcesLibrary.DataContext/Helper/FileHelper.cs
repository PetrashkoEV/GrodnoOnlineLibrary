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
                case "application/vnd.ms-word":
                case "application/vnd.oasis.opendocument.text":
                case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                case "application/msword":
                case "application/rtf":
                case "text/plain":
                case "text/html":
                case "application/vnd.ms-excel":
                case "application/vnd.ms-powerpoint":
                case "application/vnd.openxmlformats-officedocument.presentationml.presentation":
                case "application/vnd.ms-exce":
                case "application/postscript":
                case "image/x-photoshop":
                case "image/svg+xml":
                case "image/tiff":
                    return FileType.Document;
                case "audio/mp3":
                case "audio/mpeg3":
                case "audio/x-wav":
                case "audio/x-mpeg":
                case "application/ogg":
                    return FileType.Audio;
                case "image/jpeg":
                case "image/pjpeg":
                case "image/png":
                case "image/vnd.microsoft.icon":
                case "image/bmp":
                case "image/gif":
                    return FileType.Image;
                case "video/mp4":
                    return FileType.Video;
            }
            return FileType.SelectAll;
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
