using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TranVanDiem_231230742_de02.Models;

namespace TranVanDiem_231230742_de02.Controllers
{
    public class tvdHomeController : Controller
    {
        private readonly ILogger<tvdHomeController> _logger;

        public tvdHomeController(ILogger<tvdHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult tvdIndex()
        {
            return View();
        }

        public IActionResult tvdAbout()
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
