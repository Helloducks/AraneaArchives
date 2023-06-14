using Microsoft.AspNetCore.Mvc;

namespace AraneaArchives.Controllers
{
    public class ReadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
