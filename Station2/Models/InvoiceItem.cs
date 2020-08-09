using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public class InvoiceItem
    {
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }

        public Invoice Invoice { get; set; }
        public ItemMaster Item { get; set; }
    }
}
