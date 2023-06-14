using AraneaArchives.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AraneaArchives.Controllers
{
    public class ReadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReadController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null || _context.Notes == null)
            {
                return NotFound();
            }

            var directories = _context.Notes.Where(n => n.DirectoryId == id).ToList();
            if (directories == null)
            {
                return NotFound();
            }
            
            return View(directories);
        }

        public async Task<IActionResult> OpenPage(int? id)
        {
            if (id == null || _context.Notes == null)
            {
                return NotFound();
            }

            var notes = await _context.Notes.FindAsync(id);
            if (notes == null)
            {
                return NotFound();
            }
            return View(notes);
        }


    }
}
