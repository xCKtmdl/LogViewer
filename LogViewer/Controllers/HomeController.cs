using LogViewer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LogViewer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
           // HttpContext.Session.SetString("userName", "The Doctor");
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }
        /*
        [HttpPost]
        public IActionResult SaveUploadedFile(IFormFile file)
       
        {
            int i = 6;
            return CreatedAtAction("Index", "Dashboard", null, null);
        }
        */
                [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
