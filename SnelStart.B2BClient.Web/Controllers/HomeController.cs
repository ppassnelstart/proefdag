using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SnelStart.B2BClient.Web.Models;

namespace SnelStart.B2BClient.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Lees hier alles over Paul";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Paul's contactgegevens";

            return View();
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
