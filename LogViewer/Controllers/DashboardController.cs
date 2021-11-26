using LogViewer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LogViewer.CEFParse;
using LogViewer.Models.CEF;
using LogViewer.Session;
using System.Text;
using LogViewer.Logging;

namespace LogViewer.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
        }

     
        [HttpGet]
        public IActionResult Index()
        {
          //  var name = HttpContext.Session.GetString("userName");
            return View("Index");
        }

        [HttpPost]
        public IActionResult SaveUploadedFile(IFormFile file)

        {
           try
            {
                
                long length = file.Length;
                if (length > 0)
                {
                    using var fileStream = file.OpenReadStream();
                    byte[] bytes = new byte[length];

                    StreamReader reader = new StreamReader(fileStream);
                    string text = reader.ReadToEnd();

                    CEFParser cefParser = new CEFParser();
                    CEFs listOfCEFs = cefParser.GetCEFs(file,text);

                    HttpContext.Session.Set<CEFs>("CEFData", listOfCEFs);

                }
               



                return Content("true");
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Exception Message: " + ex.Message);
                sb.AppendLine("Exception StackTrace: " + ex.StackTrace);
                OutLog log = new OutLog();
                log.Log(sb.ToString());
                return Error();
            }



           
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
