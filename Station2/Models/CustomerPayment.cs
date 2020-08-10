using Station2.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public class CustomerPayment
    {
        [Required]
        [Key]
        public int PaymentId { get; set; }

        //[Required]
        public int InvoiceId { get; set; }
        [Required]
        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethod { get; set; } //Cash Card
        [Required]
        [Display(Name = "Payment Type")]
        public PaymentType PaymentType { get; set; } //Full payment
        [Required]
        [Display(Name = "Payment Amount")]
        public float NetAmount { get; set; }
        [Required]
        [Display(Name = "Cash")]
        public float Cash { get; set; }
        [Required]
        [Display(Name = "Balance")]
        public float Balance { get; set; }
        //[Required]
        //[Display(Name = "Remaining Amount")]
        //public float RemainAmount { get; set; }
        [Required]
        [Display(Name = "Payment Status")]
        public PaymentStatus PaymentStatus { get; set; } //Payment comleted or more to play

        public Invoice Invoice { get; set; }
    }
}
