using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public ItemMaster Item { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
