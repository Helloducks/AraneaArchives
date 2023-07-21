using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AraneaArchives.Data;
using AraneaArchives.Models;
using Microsoft.AspNetCore.Authorization;

namespace AraneaArchives.Controllers
{
    [Authorize]
    public class NotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Notes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Notes.Include(n => n.Directorys);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Notes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notes == null)
            {
                return NotFound();
            }

            var notes = await _context.Notes
                .Include(n => n.Directorys)
                .FirstOrDefaultAsync(m => m.NotesId == id);
            if (notes == null)
            {
                return NotFound();
            }

            return View(notes);
        }

        // GET: Notes/Create
        public IActionResult Create()
        {
            ViewData["DirectoryId"] = new SelectList(_context.Directory, "DirectoryId", "DirectoryName");
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NotesId,NotesName,NotesContents,DirectoryId")] Notes notes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DirectoryId"] = new SelectList(_context.Directory, "DirectoryId", "DirectoryName", notes.DirectoryId);
            return View(notes);
        }

        // GET: Notes/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["DirectoryId"] = new SelectList(_context.Directory, "DirectoryId", "DirectoryName", notes.DirectoryId);
            return View(notes);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NotesId,NotesName,NotesContents,DirectoryId")] Notes notes)
        {
            if (id != notes.NotesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotesExists(notes.NotesId))
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
            ViewData["DirectoryId"] = new SelectList(_context.Directory, "DirectoryId", "DirectoryName", notes.DirectoryId);
            return View(notes);
        }

        // GET: Notes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notes == null)
            {
                return NotFound();
            }

            var notes = await _context.Notes
                .Include(n => n.Directorys)
                .FirstOrDefaultAsync(m => m.NotesId == id);
            if (notes == null)
            {
                return NotFound();
            }

            return View(notes);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Notes'  is null.");
            }
            var notes = await _context.Notes.FindAsync(id);
            if (notes != null)
            {
                _context.Notes.Remove(notes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotesExists(int id)
        {
          return (_context.Notes?.Any(e => e.NotesId == id)).GetValueOrDefault();
        }
    }
}
