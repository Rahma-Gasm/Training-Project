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
    public class Activity_listController : Controller
    {
        private readonly DataContext _context;

        public Activity_listController(DataContext context)
        {
            _context = context;
        }

        // GET: Activity_list
        public async Task<IActionResult> Index()
        {
            return View(await _context.activity_List.ToListAsync());
        }

        // GET: Activity_list/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity_list = await _context.activity_List
                .FirstOrDefaultAsync(m => m.activity_id == id);
            if (activity_list == null)
            {
                return NotFound();
            }

            return View(activity_list);
        }

        // GET: Activity_list/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Activity_list/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("activity_id,admin_name,update_date,category_name,sub_category_name,process_name,file_name")] activity_list activity_list)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activity_list);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activity_list);
        }

        // GET: Activity_list/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity_list = await _context.activity_List.FindAsync(id);
            if (activity_list == null)
            {
                return NotFound();
            }
            return View(activity_list);
        }

        // POST: Activity_list/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("activity_id,admin_name,update_date,category_name,sub_category_name,process_name,file_name")] activity_list activity_list)
        {
            if (id != activity_list.activity_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activity_list);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!activity_listExists(activity_list.activity_id))
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
            return View(activity_list);
        }

        // GET: Activity_list/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity_list = await _context.activity_List
                .FirstOrDefaultAsync(m => m.activity_id == id);
            if (activity_list == null)
            {
                return NotFound();
            }

            return View(activity_list);
        }

        // POST: Activity_list/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activity_list = await _context.activity_List.FindAsync(id);
            _context.activity_List.Remove(activity_list);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool activity_listExists(int id)
        {
            return _context.activity_List.Any(e => e.activity_id == id);
        }
    }
}
