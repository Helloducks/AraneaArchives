using Microsoft.AspNetCore.Mvc;

namespace AraneaArchives.Controllers
{
    public class AddNoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
