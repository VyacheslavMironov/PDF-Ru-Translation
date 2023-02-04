using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using PRT.Web.Models;
using System.Diagnostics;

namespace PRT.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IWebHostEnvironment _appEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment appEnvironment)
        {
            _logger = logger;
            _appEnvironment = appEnvironment;
        }

        [HttpPost]
        [HttpGet]
        public IActionResult Index(IFormFile uploadedFile)
        {
            TranslatorModel Result = new TranslatorModel();
            // bool UploadModelRequest = Result.Translate(uploadedFile, this._appEnvironment);
            if (HttpMethod.Post != null)
            {
                if (uploadedFile != null)
                {
                    if (Result.Translate(uploadedFile, this._appEnvironment) == false)
                    {
                        ViewData["Error"] = "Слишком большой размер файла. Файл не должен превышать 100 МБ.";
                    }
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}