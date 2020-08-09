using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public class CustomerOrderDetailRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;


        public CustomerOrderDetailRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
            //uses the appdbcontext ans shopping cart
        }

        /*public decimal GetShoppingCartTotal(string ShoppingCartId)
        {
            var total = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Item.Price * c.Amount).Sum();
            return total;
        }*/
        /*public void CreateOrder(CustomerOrderDetail total)
        //use the repositories to create both order and its order details
        {
            total.OrderPlaced = DateTime.Now;

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            total.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            _appDbContext.CustomerOrderDetails.Add(total);


            _appDbContext.SaveChanges();*/




        }
    }

