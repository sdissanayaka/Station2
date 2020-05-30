using Microsoft.AspNetCore.Mvc;
using Station2.Models;
using Station2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Components //like a mini controller
{
    public class ShoppingCartSummary: ViewComponent

    {
        private readonly ShoppingCart _shoppingCart;
        //bring the shopping cart

        public ShoppingCartSummary(ShoppingCart shoppingCart) //constructor injection
        {
            _shoppingCart = shoppingCart;
            //get instances of the shopping cart through dependency injection
        }

        public IViewComponentResult Invoke()
        {

            var items = _shoppingCart.GetShoppingCartItems(); //go to the shopping cart and get its items
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel //pass shopping cart and shopping cart total
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()

            };
            return View(shoppingCartViewModel);
        }
    }
}
