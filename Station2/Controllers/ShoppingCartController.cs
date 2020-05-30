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
    public class ShoppingCartController : Controller
    {
        private readonly IItemMasterRepository _itemRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IItemMasterRepository itemRepository, ShoppingCart shoppingCart)
        {
            _itemRepository = itemRepository;
            _shoppingCart = shoppingCart;
        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }
        public RedirectToActionResult AddToShoppingCart(int itemId) //pass the id of the item that is going to cart
        {
            var selectedItem = _itemRepository.AllItems.FirstOrDefault(p => p.ItemId == itemId);

            if (selectedItem != null)
            {
                _shoppingCart.AddToCart(selectedItem, 1);
            }
            return RedirectToAction("Index"); //redirect user to the index
        }

        public RedirectToActionResult RemoveFromShoppingCart(int itemId)
        {
            var selectedItem = _itemRepository.AllItems.FirstOrDefault(p => p.ItemId == itemId);

            if (selectedItem != null)
            {
                _shoppingCart.RemoveFromCart(selectedItem);
            }
            return RedirectToAction("Index");
        }

    }
}

