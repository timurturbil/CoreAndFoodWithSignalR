using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreAndFood.Controllers
{
    [Authorize(Roles = "admin1, admin2")]
    public class FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet("GetAllHeaders")]
        public IActionResult GetAllHeaders()
        {
            try
            {
                List<string> requestHeaders = new List<string>();
                foreach (var header in Request.Headers)
                {
                    requestHeaders.Add(header.Key);
                }
                return Content("asdasd");
            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }
        }


        [HttpPost("FileUpload")]
        public async Task<IActionResult> Index(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    // full path to file in temp location
                    var filePath = Path.GetTempFileName(); //we are using Temp file name just for the example. Add your own file path.
                    filePaths.Add(filePath);
                    using var stream = new FileStream(filePath, FileMode.Create);
                    await formFile.CopyToAsync(stream);
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            return Content($"filePaths {filePaths[0]} // {files.Count} // {size}");
            //return Ok(new { count = files.Count, size, filePaths });
        }
    }
}
