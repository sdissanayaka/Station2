using Station2.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public class Invoice
    {
        [Required]
        [Key]
        public int InvoiceId { get; set; }
        [Required]
        public int CustomerOrderId { get; set; }
        [Required]
        [Display(Name = "Prepared By")]
        public Users User { get; set; }
        [Required]
        [Display(Name = "Invoice Date")]
        public DateTime InvoiceDate { get; set; }
        [Required]
        [Display(Name = "State")]
        public InvoiceState InvoiceState { get; set; }
        [Display(Name = "Invoice Total")]
        public double? InvoiceTotal { get; set; }

        public CustomerOrder CustomerOrder { get; set; }
        public ICollection<CustomerPayment> Payments { get; set; }
        public ICollection<InvoiceItem> InvoiceItem { get; set; }

    }
}
