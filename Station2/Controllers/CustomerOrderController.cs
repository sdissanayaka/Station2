using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Station2.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Station2.Controllers
{
    
        public class CustomerOrderController : Controller
        {
            private readonly ICustomerOrderRepository _orderRepository;
            private readonly ShoppingCart _shoppingCart;

            public CustomerOrderController(ICustomerOrderRepository orderRepository, ShoppingCart shoppingCart)
            {
                _orderRepository = orderRepository;
                _shoppingCart = shoppingCart;
            }

            // GET: /<controller>/
            public IActionResult Checkout()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Checkout(CustomerOrder order)
            {
                var items = _shoppingCart.GetShoppingCartItems();
                _shoppingCart.ShoppingCartItems = items;

                if (_shoppingCart.ShoppingCartItems.Count == 0)
                {
                    ModelState.AddModelError("", "Your cart is empty, add some items first");
                }

                if (ModelState.IsValid)
                {
                    _orderRepository.CreateOrder(order);
                    _shoppingCart.ClearCart();
                    return RedirectToAction("CheckoutComplete");
                }
                return View(order);
            }

            public IActionResult CheckoutComplete()
            {
                ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon receive your order!";
                return View();
            }
        }
    }
