using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaudiaDocumentManagement.Models;
using SaudiaDocumentManagment;


namespace SaudiaDocumentManagement.Controllers
{
    public class filesController : Controller
    {
        private readonly DataContext _context;

        public filesController(DataContext context)
        {
            _context = context;
        }

        // GET: files
        public async Task<IActionResult> Index()
        {
            return View(await _context.files.ToListAsync());
        }

        // GET: files/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var files = await _context.files
                .FirstOrDefaultAsync(m => m.file_id == id);
            if (files == null)
            {
                return NotFound();
            }

            return View(files);
        }

        // GET: files/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: files/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("file_id,name,file_number,file_category,pdf_file,category_id")] files files)
        {
            if (ModelState.IsValid)
            {
                _context.Add(files);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(files);
        }

        // GET: files/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var files = await _context.files.FindAsync(id);
            if (files == null)
            {
                return NotFound();
            }
            return View(files);
        }

        // POST: files/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("file_id,name,file_number,file_category,pdf_file,category_id")] files files)
        {
            if (id != files.file_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(files);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!filesExists(files.file_id))
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
            return View(files);
        }

        // GET: files/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var files = await _context.files
                .FirstOrDefaultAsync(m => m.file_id == id);
            if (files == null)
            {
                return NotFound();
            }

            return View(files);
        }

        // POST: files/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var files = await _context.files.FindAsync(id);
            _context.files.Remove(files);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool filesExists(int id)
        {
            return _context.files.Any(e => e.file_id == id);
        }
    }
}
