using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace YourNamespace.Controllers
{
    public class SpaFallbackController : Controller
    {
        private readonly IFileProvider _fileProvider;

        public SpaFallbackController(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public IActionResult Index()
        {
            var fileInfo = _fileProvider.GetFileInfo("index.html");

            if (!fileInfo.Exists)
            {
                return NotFound();
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileInfo.PhysicalPath);

            return PhysicalFile(filePath, "text/html");
        }
    }
}
