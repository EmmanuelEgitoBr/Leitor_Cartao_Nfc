using System.Diagnostics;
using DigitalNfcCardReader.Web.Models;
using DigitalNfcCardReader.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DigitalNfcCardReader.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NFCReaderService _nfcReaderService;


        public HomeController(ILogger<HomeController> logger, NFCReaderService nfcReaderService)
        {
            _logger = logger;
            _nfcReaderService = nfcReaderService;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult ReadCard()
        {
            var cardData = _nfcReaderService.ReadCard();
            return Json(new { message = cardData });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
