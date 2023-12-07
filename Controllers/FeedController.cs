using Microsoft.AspNetCore.Mvc;
using SnapBites.Models;
using System.Diagnostics;

namespace SnapBites.Controllers
{
    public class FeedController : Controller
    {
        private readonly ILogger<FeedController> _logger;

        public FeedController(ILogger<FeedController> logger)
        {
            _logger = logger;
        }

        public IActionResult Feed()
        {
            return View();
        }

        public IActionResult Publicar()
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
