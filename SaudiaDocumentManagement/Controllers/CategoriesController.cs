using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaudiaDocumentManagement.Models;
using SaudiaDocumentManagment;
using SaudiaDocumentManagement.ViewModels;

namespace SaudiaDocumentManagement.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.category.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.category
                .FirstOrDefaultAsync(m => m.category_id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        [HttpGet]
        public IActionResult Create()
        {
           return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(category category)
        {
            if (ModelState.IsValid)
            {
                if (!categoryExists(category.category_name))
                {
                    _context.Add(category);
                    await _context.SaveChangesAsync();
                }
                /** else
                 {
                 
                 }**/
                return RedirectToAction(nameof(Index));
            }
            return View("Index", category);
        }
        [HttpGet]
        public IActionResult CreateSub()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSub(CreateSubCategoryViewModel model)
        {
            category Sub = new category();
            if (ModelState.IsValid)
            {
                if (!categoryExists(model.SubCategory))
                {
                    var category = SearchByName(model.Category);
                    Sub.category_name = model.SubCategory;
                    Sub.parent_id = category.category_id;
                    _context.Add(Sub);
                    await _context.SaveChangesAsync();
                }
              /**  else
                {
                    return RedirectToAction(nameof(Index));
                }**/

            }
            return RedirectToAction(nameof(Index));
        }


        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("category_id,category_name,parent_id")] category category)
        {
            if (id != category.category_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!categoryExists(category.category_id))
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
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.category
                .FirstOrDefaultAsync(m => m.category_id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.category.FindAsync(id);
            _context.category.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool categoryExists(int id)
        {
            return _context.category.Any(e => e.category_id == id);
        }
        private bool categoryExists(String name)
        {
            return _context.category.Any(e => e.category_name == name);
        }
        public category SearchByName(string categoryName)
        {
            category Category = null;
            if (!String.IsNullOrEmpty(categoryName))
            {
                //Category = _context.category.FirstOrDefault(c => c.category_name == categoryName);
                Category = _context.category.Where(e => e.category_name == categoryName).FirstOrDefault();
            }
            return Category;
        }
    }

}




/////////////////////////////***************************************************************
