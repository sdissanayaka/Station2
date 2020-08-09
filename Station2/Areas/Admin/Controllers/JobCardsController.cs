using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Station2.Models;
using Station2.ViewModels;
using System.Reflection;

namespace Station2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class JobCardsController : Controller
    {
        private readonly AppDbContext _context;


        public JobCardsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //return View(await _context.CustomerOrders.ToListAsync());
            return View(await _context.CustomerOrders.ToListAsync());

        }

        public async Task<IActionResult> Details(int? id)
        {
            JobCardViewModel cardViewModel = new JobCardViewModel()
            {
                //var supplier = await _context.Suppliers
                //.FirstOrDefaultAsync(m => m.SupplierId == id);
                CustomerOrder = await _context.CustomerOrders.FirstOrDefaultAsync(m => m.CustomerOrderId == id),
                //CustomerOrderDetail = await _context.CustomerOrderDetails.FirstOrDefaultAsync(m => m.CustomerOrderId == id)


                CustomerOrderDetail = await _context.CustomerOrderDetails.Include(i => i.CustomerOrder).Include(i => i.ItemMaster)
                .Where(a => a.CustomerOrderId == id).ToListAsync()
                /*if (id != null)
                {
                ViewData["Customer"] = id.Value;
                Instructor instructor = viewModel.Instructors.Where(
                    i => i.ID == id.Value).Single();
                viewModel.Courses = instructor.CourseAssignments.Select(s => s.Course);
                }*/

                //IEnumerable < CustomerOrderDetail> CustomerOrderDetail = _context.CustomerOrderDetails
                //.Include(m => m.CustomerOrder)
                //.Where(a => a.CustomerOrderId == id)
                //.SingleOrDefault()


            };
            return View(cardViewModel);
        }

        /*public ActionResult Details(int? id)
        {
            
            CustomerOrderDetail artist = _context.CustomerOrderDetails
                .Include(m => m.CustomerOrder)
                .Where(a => a.CustomerOrderId == id)
                .SingleOrDefault();
            
            var view = new JobCardViewModel
            {
                ID = artist.ID,
                Name = artist.Name,
                Songs = artist.Songs.ToList()
            };
            return View(view);
        }*/
        public IActionResult Create( Invoice invoice)
        {
            //if (ModelState.IsValid)
            //{
                //_context.Add(customerOrder);
               // await _context.SaveChangesAsync();
               // return RedirectToAction("Create", "Invoices", new { id = customerOrder.CustomerOrderId });
            //}
            //return View(customerOrder);
            return RedirectToAction("Create", "Invoices");

            // [Bind("CustomerOrderId,CustomerOrderDetailId,FirstName,LastName,AddressLine1,PhoneNumber,Email")]
        }           //new { id = invoice.InvoiceId }

    }
}