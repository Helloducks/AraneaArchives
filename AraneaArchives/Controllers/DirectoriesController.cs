using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AraneaArchives.Data;
using AraneaArchives.Models;
using Directory = AraneaArchives.Models.Directory;

namespace AraneaArchives.Controllers
{
    public class DirectoriesController : Controller
    {
        private readonly AraneaArchivesContext _context;

        public DirectoriesController(AraneaArchivesContext context)
        {
            _context = context;
        }

        // GET: Directories
        public async Task<IActionResult> Index()
        {
            return _context.Directory != null ?
                        View(await _context.Directory.ToListAsync()) :
                        Problem("Entity set 'AraneaArchivesContext.Directory'  is null.");
        }

        // GET: Directories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Directory == null)
            {
                return NotFound();
            }

            var directory = await _context.Directory
                .FirstOrDefaultAsync(m => m.DirectoryId == id);
            if (directory == null)
            {
                return NotFound();
            }

            return View(directory);
        }

        // GET: Directories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Directories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DirectoryId,DirectoryName")] Directory directory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(directory);
        }

        // GET: Directories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Directory == null)
            {
                return NotFound();
            }

            var directory = await _context.Directory.FindAsync(id);
            if (directory == null)
            {
                return NotFound();
            }
            return View(directory);
        }

        // POST: Directories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DirectoryId,DirectoryName")] Directory directory)
        {
            if (id != directory.DirectoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectoryExists(directory.DirectoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(directory);
        }

        // GET: Directories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Directory == null)
            {
                return NotFound();
            }

            var directory = await _context.Directory
                .FirstOrDefaultAsync(m => m.DirectoryId == id);
            if (directory == null)
            {
                return NotFound();
            }

            return View(directory);
        }

        // POST: Directories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Directory == null)
            {
                return Problem("Entity set 'AraneaArchivesContext.Directory'  is null.");
            }
            var directory = await _context.Directory.FindAsync(id);
            if (directory != null)
            {
                _context.Directory.Remove(directory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectoryExists(int id)
        {
            return (_context.Directory?.Any(e => e.DirectoryId == id)).GetValueOrDefault();
        }
    }
}
