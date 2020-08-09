using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Station2.Models;

namespace Station2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerPaymentsController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerPaymentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CustomerPayments
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.CustomerPayments.Include(c => c.Invoice);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/CustomerPayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerPayment = await _context.CustomerPayments
                .Include(c => c.Invoice)
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (customerPayment == null)
            {
                return NotFound();
            }

            return View(customerPayment);
        }

        // GET: Admin/CustomerPayments/Create
        /*public IActionResult Create()
        {
            ViewData["InvoiceId"] = new SelectList(_context.Invoice, "InvoiceId", "InvoiceId");
            return View();
        }*/
        public async Task<IActionResult> CreateAsync(int? id)
        {
            var invoice = await _context.Invoice.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }



            ViewData["InvoiceID"] = new SelectList(_context.Invoice, "InvoiceId", "InvoiceId", invoice.InvoiceId);
            return View();
        }


        // POST: Admin/CustomerPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentId,InvoiceId,PaymentMethod,PaymentType,NetAmount,Cash,Balance,RemainAmount,PaymentStatus")] CustomerPayment customerPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InvoiceId"] = new SelectList(_context.Invoice, "InvoiceId", "InvoiceId", customerPayment.InvoiceId);
            return View(customerPayment);
        }

        // GET: Admin/CustomerPayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerPayment = await _context.CustomerPayments.FindAsync(id);
            if (customerPayment == null)
            {
                return NotFound();
            }
            ViewData["InvoiceId"] = new SelectList(_context.Invoice, "InvoiceId", "InvoiceId", customerPayment.InvoiceId);
            return View(customerPayment);
        }

        // POST: Admin/CustomerPayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentId,InvoiceId,PaymentMethod,PaymentType,NetAmount,Cash,Balance,RemainAmount,PaymentStatus")] CustomerPayment customerPayment)
        {
            if (id != customerPayment.PaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerPaymentExists(customerPayment.PaymentId))
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
            ViewData["InvoiceId"] = new SelectList(_context.Invoice, "InvoiceId", "InvoiceId", customerPayment.InvoiceId);
            return View(customerPayment);
        }

        // GET: Admin/CustomerPayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerPayment = await _context.CustomerPayments
                .Include(c => c.Invoice)
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (customerPayment == null)
            {
                return NotFound();
            }

            return View(customerPayment);
        }

        // POST: Admin/CustomerPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerPayment = await _context.CustomerPayments.FindAsync(id);
            _context.CustomerPayments.Remove(customerPayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerPaymentExists(int id)
        {
            return _context.CustomerPayments.Any(e => e.PaymentId == id);
        }
    }
}
