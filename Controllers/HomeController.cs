using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using static System.Net.Mime.MediaTypeNames;
using System.Buffers.Text;

namespace netcorefileupload.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public JsonResult UploadFile(string DmFile1, string Name)
        {
            string fileType = Name.Substring(Name.IndexOf("."));
            string fileName = Name.Replace(fileType, "");

            DmFile1 = DmFile1.Replace("data:application/vnd.ms-excel;base64,", "").Replace("data:text/xml;base64,", "").Replace("data:application/octet-stream;base64,", "").Replace("data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64,", "").Replace("data:application/pdf;base64,", "");

            byte[] bytes = System.Convert.FromBase64String(DmFile1);
            var stream = new MemoryStream(bytes);

            IFormFile DmFileId = new FormFile(stream, 0, bytes.Length, "DmFileId", fileName + fileType);



            return Json(true);
        }
    }
}
