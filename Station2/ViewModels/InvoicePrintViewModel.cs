using Station2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.ViewModels
{
    public class InvoicePrintViewModel
    {
        public List<CustomerOrderDetail> CustomerOrderDetail { get; set; }
        //public IEnumerable<CustomerOrder> CustomerOrder { get; set; }
        public CustomerOrder CustomerOrder { get; set; }
        //public CustomerOrderDetail CustomerOrderDetail { get; set; }
        //public List<CustomerPayment> CustomerPayments { get; set; }
        public List<CustomerPayment> CustomerPayments { get; set; }


    }
}
