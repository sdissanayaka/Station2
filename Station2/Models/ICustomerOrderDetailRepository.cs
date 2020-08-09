using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    interface ICustomerOrderDetailRepository
    {
        void CreateOrder(CustomerOrderDetail total);
        //ShoppingCart GetShoppingCartTotal(string ShoppingCartId);


    }
}
