using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public class CustomerOrderDetail
    {
        public int CustomerOrderDetailId { get; set; }
        public int CustomerOrderId { get; set; }
        
        public int ItemId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("ItemId")]
        public ItemMaster ItemMaster { get; set; }

        [ForeignKey("CustomerOrderId")]
        public CustomerOrder CustomerOrder { get; set; }
    }
}
 