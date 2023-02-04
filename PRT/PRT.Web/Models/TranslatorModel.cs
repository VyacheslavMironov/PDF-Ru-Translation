
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace PRT.Web.Models
{
    public class TranslatorModel
    {
        public void RuTranslate()
        {

        }
        public bool Translate(IFormFile uploadedFile, IWebHostEnvironment _appEnvironment, string Mode = "Russian")
        {
            if (uploadedFile != null)
            {
                string path = "/Files/" + uploadedFile.FileName;

                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    uploadedFile.CopyToAsync(fileStream);
                }
                FileModel file = new FileModel { FileName = uploadedFile.FileName };
                return true;
            }
            return false;
        }
    }
}
