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
        }

        public void CreateOrder(CustomerOrder order)
            //use the repositories to create both order and its order details
        {
            order.OrderPlaced = DateTime.Now;

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<CustomerOrderDetail>();
            //adding the order with its details

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new CustomerOrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    ItemId = shoppingCartItem.Item.ItemId,
                    Price = shoppingCartItem.Item.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _appDbContext.CustomerOrders.Add(order);

            _appDbContext.SaveChanges();
        }
    }
}

