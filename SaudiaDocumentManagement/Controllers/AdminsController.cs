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
    public class adminsController : Controller
    {
        private readonly DataContext _context;

        public adminsController(DataContext context)
        {
            _context = context;
        }

        // GET: admins
        public async Task<IActionResult> Index()
        {
            return View(await _context.admin.ToListAsync());
        }

        // GET: admins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.admin
                .FirstOrDefaultAsync(m => m.admin_id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: admins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("admin_id,name,password,date_of_birth,mobile_number")] admin admin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: admins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.admin.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        // POST: admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("admin_id,name,password,date_of_birth,mobile_number")] admin admin)
        {
            if (id != admin.admin_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!adminExists(admin.admin_id))
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
            return View(admin);
        }

        // GET: admins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.admin
                .FirstOrDefaultAsync(m => m.admin_id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admin = await _context.admin.FindAsync(id);
            _context.admin.Remove(admin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool adminExists(int id)
        {
            return _context.admin.Any(e => e.admin_id == id);
        }
    }
}
