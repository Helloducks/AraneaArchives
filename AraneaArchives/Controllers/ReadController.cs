using AraneaArchives.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AraneaArchives.Controllers
{
    [Authorize]
    public class ReadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReadController(ApplicationDbContext context)
        {
            _context = context;
        }
        //this will grab all the notes file linked to clicked repo
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
        //this will show the contents of the clicked note
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
