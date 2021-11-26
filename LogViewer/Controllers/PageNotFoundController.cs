using Microsoft.AspNetCore.Mvc;

namespace LogViewer.Controllers
{
    public class PageNotFoundController : Controller
    {
        [Route("{*url}", Order = 999)]
        public IActionResult CatchAll()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}
