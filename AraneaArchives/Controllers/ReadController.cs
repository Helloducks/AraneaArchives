using AraneaArchives.Data;
using AraneaArchives.Models;
using Microsoft.AspNetCore.Mvc;

namespace AraneaArchives.Controllers
{
    

    public class ReadController : Controller
    {
        //this will connection to the db 
        private readonly AraneaArchivesContext _context;

        //we shall create an constructor that will require connection to the db
        public ReadController(AraneaArchivesContext context) {
            _context = context;
        }
        public IActionResult Index(int DirID)
        {
            
            var notes = _context.Notes.Where(n => n.DirectoryId == DirID).ToList();
            return View(notes);
        }
        public IActionResult ReadNote() {
            
            return View();
        }
    }
}
