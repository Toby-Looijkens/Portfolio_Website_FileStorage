using Microsoft.AspNetCore.Mvc;
using Portfolio_Website_Filestorage.PublicClasses;
using System.Security.AccessControl;

namespace Portfolio_Website_Filestorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileManagerController : Controller
    {
        [HttpPost(nameof(UploadFile))]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            return Ok(new UploadHandler().Upload(file));
        }

        [HttpPost(nameof(GetFileByID))]
        public async Task<IActionResult> GetFileByID(TransferableFile file)
        {
            DownloadHandler downloadHandler = new DownloadHandler();
            return File(downloadHandler.GetFileAsByteArray(file), "multipart/form-data", file.Name);
        }

        [HttpGet(nameof(GetAllFiles))]
        public async Task<IActionResult> GetAllFiles()
        {
            return View();
        }

        [HttpDelete(nameof(DeleteFile))]
        public async Task<IActionResult> DeleteFile(string path)
        {
            return View();
        }
    }
}
