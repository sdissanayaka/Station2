using Station2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.ViewModels
{
    public class ShoppingCartViewModel
    {
        //internal DateTime OrderPlaced;
        //internal decimal OrderTotal;
        //internal List<CustomerOrderDetail> OrderDetails;

        public ShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }

        public IList<ItemMaster> ItemList { get; set; }
        public CustomerOrder CustomerOrder { get; set; }
    }
}
