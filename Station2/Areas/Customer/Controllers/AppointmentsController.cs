using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Station2.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class AppointmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}