using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleApp.WebApp.Models;

namespace VehicleApp.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "𝕎𝕖𝕝𝕔𝕠𝕞𝕖 𝕋𝕠 𝕍𝕖𝕙𝕚𝕔𝕝𝕖 𝔸𝕡𝕡";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Email: vehicle_app@gmail.com";

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
