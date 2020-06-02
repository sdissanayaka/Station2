using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public class CustomerOrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public ItemMaster ItemMaster { get; set; }
        public CustomerOrder CustomerOrder { get; set; }
    }
}
