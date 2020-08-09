using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Station2.Models;
using Station2.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Station2.Controllers
{
    [Area ("Customer")]
    
        public class CustomerOrderController : Controller
        {
        private readonly ICustomerOrderRepository _orderRepository;
            private readonly ShoppingCart _shoppingCart;
        //using order repository and shopping cart through dependency injection and get instances of both of them
            public CustomerOrderController(ICustomerOrderRepository orderRepository, ShoppingCart shoppingCart)
            {
                _orderRepository = orderRepository;
                _shoppingCart = shoppingCart;
            }

            // GET: /<controller>/
            public IActionResult Checkout()
            //will be invoked when we are creating the order
            {
                return View();
            }

            [HttpPost]
            //this method is need to be called when HTTP POST is done
            public IActionResult Checkout(CustomerOrder order)
            //order is created by using model binding
            {
                var items = _shoppingCart.GetShoppingCartItems();
                _shoppingCart.ShoppingCartItems = items;

                if (_shoppingCart.ShoppingCartItems.Count == 0)
                {
                    ModelState.AddModelError("", "Your cart is empty, add some items first");
                }

                if (ModelState.IsValid)//check model state is valid property
                //IsValid Property is going to check the state of the odere model instance 
                {
                    _orderRepository.CreateOrder(order);
                    _shoppingCart.ClearCart();
                    return RedirectToAction("CheckoutComplete");
                }
                return View(order);
            }

            public IActionResult CheckoutComplete(int CustomerOrderId)
            {
                ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon receive your order!";
                return View(CustomerOrderId);
            }
        }
    }
