using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Station2.Models;
using Station2.ViewModels;

namespace Station2.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class PrintController : Controller
    {
        private readonly AppDbContext _context;


        public PrintController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Details(int? id)
        {
            InvoicePrintViewModel cardViewModel = new InvoicePrintViewModel()
            {

                CustomerOrder = await _context.CustomerOrders.FirstOrDefaultAsync(m => m.CustomerOrderId == id),


                CustomerOrderDetail = await _context.CustomerOrderDetails.Include(i => i.CustomerOrder).Include(i => i.ItemMaster)
                .Where(a => a.CustomerOrderId == id).ToListAsync(),

                CustomerPayments = await _context.CustomerPayments.Include(i => i.Invoice)
                .Where(a => a.InvoiceId == id).ToListAsync()



            };
            return View(cardViewModel);
        }

    }
}