using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public class CashBook
    {
        [Required]
        [Key]
        public int CashTableId { get; set; }
        [Required]
        [Display(Name = "Amount")]
        public double Amount { get; set; }
        [Required]
        [Display(Name = "Cash Type ")]
        public CashBookType CashBookType { get; set; }
        public int PaymentId { get; set; }


        //------------------------------------------------
        public CustomerPayment Payment { get; set; }
    }
}
