using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalResourcesLibrary.DataContext.Interfaces;
using DigitalResourcesLibrary.DataContext.Services;

namespace DigitalResourcesLibrary.Controllers
{
    public class FilesController : Controller
    {
        private readonly IFileService _fileService = new FileService();

        public FileContentResult DownloadFile(int id, string filename)
        {
            var dataFile = _fileService.СontentFile(id);
            Response.AddHeader("Content-Disposition", "inline; filename=" + filename);
            return new FileContentResult(dataFile, "arraybuffer");
        }

    }
}
