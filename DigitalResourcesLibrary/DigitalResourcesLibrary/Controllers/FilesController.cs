using System.Web.Mvc;
using DigitalResourcesLibrary.DataContext.Interfaces;

namespace DigitalResourcesLibrary.Controllers
{
    public class FilesController : Controller
    {
        private readonly IFileService _fileService;

        public FilesController(IFileService fileService)
        {
            this._fileService = fileService;
        }

        public FileContentResult DownloadFile(int id, string filename)
        {
            var dataFile = _fileService.СontentFile(id);
            Response.AddHeader("Content-Disposition", "inline; filename=" + filename);
            return new FileContentResult(dataFile, "arraybuffer");
        }

        public FileResult Download(int id, string filename)
        {
            var dataFile = _fileService.СontentFile(id);
            return File(dataFile, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }
    }
}
