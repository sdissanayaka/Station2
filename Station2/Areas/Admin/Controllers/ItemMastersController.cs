using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Station2.Models;

namespace Station2.Controllers
{
    [Area("Admin")]

    public class ItemMastersController : Controller
    {
        private readonly AppDbContext _context;

        public ItemMastersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ItemMasters
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ItemMaster.Include(i => i.Category);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ItemMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemMaster = await _context.ItemMaster
                .Include(i => i.Category)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (itemMaster == null)
            {
                return NotFound();
            }

            return View(itemMaster);
        }

        // GET: ItemMasters/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.ItemCategories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: ItemMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,CategoryId,ItemName,ItemDescription,Price,UOM,StockQuantity,InStock")] ItemMaster itemMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.ItemCategories, "CategoryId", "CategoryId", itemMaster.CategoryId);
            return View(itemMaster);
        }

        // GET: ItemMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemMaster = await _context.ItemMaster.FindAsync(id);
            if (itemMaster == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.ItemCategories, "CategoryId", "CategoryId", itemMaster.CategoryId);
            return View(itemMaster);
        }

        // POST: ItemMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,CategoryId,ItemName,ItemDescription,Price,UOM,StockQuantity,InStock")] ItemMaster itemMaster)
        {
            if (id != itemMaster.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemMasterExists(itemMaster.ItemId))
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
            ViewData["CategoryId"] = new SelectList(_context.ItemCategories, "CategoryId", "CategoryId", itemMaster.CategoryId);
            return View(itemMaster);
        }

        // GET: ItemMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemMaster = await _context.ItemMaster
                .Include(i => i.Category)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (itemMaster == null)
            {
                return NotFound();
            }

            return View(itemMaster);
        }

        // POST: ItemMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemMaster = await _context.ItemMaster.FindAsync(id);
            _context.ItemMaster.Remove(itemMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemMasterExists(int id)
        {
            return _context.ItemMaster.Any(e => e.ItemId == id);
        }
    }
}
