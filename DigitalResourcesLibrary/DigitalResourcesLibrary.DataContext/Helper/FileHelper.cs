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
            return FileType.Other;
        }

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
    }
}
