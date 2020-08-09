using Station2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public class CustomerOrderRepository : ICustomerOrderRepository
        //finctionalities defined in IcustomerOrderRepository class are implemented here
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;
        //uses the appdbcontext ans shopping cart

        public CustomerOrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
            //uses the appdbcontext ans shopping cart
        }

        public void CreateOrder(CustomerOrder order)
            //use the repositories to create both order and its order details
        {
            //order.OrderPlaced = DateTime.Now;

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            //order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<CustomerOrderDetail>();
            //adding the order with its details

            foreach (var shoppingCartItem in shoppingCartItems)
            //create new order detils for each shopping cart item
            {
                var orderDetail = new CustomerOrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    ItemId = shoppingCartItem.Item.ItemId,
                    Price = shoppingCartItem.Item.Price,
                    OrderPlaced = DateTime.Now,
                    OrderTotal = _shoppingCart.GetShoppingCartTotal()

                };

                order.OrderDetails.Add(orderDetail);
                //add order details to order
            }
            //in each run of this loop a new order detail is added to the appdbcontext.Customer orederdetail
            _appDbContext.CustomerOrders.Add(order);
            //add order(order details) with all order details to appdbContext. order is being tracked by EF Core

            _appDbContext.SaveChanges();
            //save both the order and order details into  my database
        }

        
    }
}

