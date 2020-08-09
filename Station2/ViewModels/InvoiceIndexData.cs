using Station2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.ViewModels
{
    public class InvoiceIndexData
    {
        public IEnumerable<Invoice> Invoice { get; set; }
        public IEnumerable<ItemMaster> Item { get; set; }
    }
}
