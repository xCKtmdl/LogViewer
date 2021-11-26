using Microsoft.AspNetCore.Mvc;

namespace LogViewer.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
