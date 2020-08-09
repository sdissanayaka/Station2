using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Station2.Models;
using Station2.ViewModels;

namespace Station2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InvoicesController : Controller
    {
        private readonly AppDbContext _context;

        public InvoicesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Invoices
        /*public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Invoice.Include(i => i.CustomerOrder)
                .Include(i => i.InvoiceItem)
                    .ThenInclude(i => i.Item);
            return View(await appDbContext.ToListAsync());
        }*/

        public async Task<IActionResult> Index(int? invoiceId, int? itemId)
        {
            var viewModel = new InvoiceIndexData();
            viewModel.Invoice = await _context.Invoice
                  .Include(i => i.CustomerOrder)
                  .Include(i => i.InvoiceItem)
                    .ThenInclude(i => i.Item)
                  .ToListAsync();

            if (invoiceId != null)
            {
                ViewData["InvoiceId"] = invoiceId.Value;
                Invoice invoice = viewModel.Invoice.Where(
                    i => i.InvoiceId == invoiceId.Value).Single();
                viewModel.Item = invoice.InvoiceItem.Select(s => s.Item);
            }
            return View(viewModel);
        }


        // GET: Admin/Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.CustomerOrder)
                .FirstOrDefaultAsync(m => m.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Admin/Invoices/Create
        public async Task<IActionResult> Create(int? id)
        { 
          var customerOrder = await _context.CustomerOrders.FindAsync(id);
            // var invoice = new Invoice();
            //invoice.InvoiceItem = new List<InvoiceItem>();
            //PopulateInvoiceItems(invoice);


            /*if (id != customerOrder.CustomerOrderId)
            {
                return NotFound();
            }*/

           // ViewData["CustomerOrderId"] = customerOrder.CustomerOrderId;

           ViewData["CustomerOrderId"] = new SelectList(_context.CustomerOrders, "CustomerOrderId", "CustomerOrderId");
            return View();
        }

        /*private void PopulateInvoiceItems(Invoice invoice)
        {
            throw new NotImplementedException();
        }*/

        // POST: Admin/Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceId,CustomerOrderId,User,InvoiceDate,InvoiceState,InvoiceTotal")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Create", "CustomerPayments", new { id = invoice.InvoiceId });

            }
            ViewData["CustomerOrderId"] = new SelectList(_context.CustomerOrders, "CustomerOrderId", "CustomerOrderId", invoice.CustomerOrderId);
            return View(invoice);
        }

        // GET: Admin/Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["CustomerOrderId"] = new SelectList(_context.CustomerOrders, "CustomerOrderId", "CustomerOrderId", invoice.CustomerOrderId);
            return View(invoice);
        }

        // POST: Admin/Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvoiceId,CustomerOrderId,User,InvoiceDate,InvoiceState,InvoiceTotal")] Invoice invoice)
        {
            if (id != invoice.InvoiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.InvoiceId))
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
            ViewData["CustomerOrderId"] = new SelectList(_context.CustomerOrders, "CustomerOrderId", "CustomerOrderId", invoice.CustomerOrderId);
            return View(invoice);
        }

        // GET: Admin/Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.CustomerOrder)
                .FirstOrDefaultAsync(m => m.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Admin/Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoice.FindAsync(id);
            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoice.Any(e => e.InvoiceId == id);
        }
    }
}
