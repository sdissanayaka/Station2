using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public interface ICustomerOrderRepository
    //interface that contain the functionality of customer order repository
    //allowas to create an order and accept the order
    {
        void CreateOrder (CustomerOrder order);
    }
}
