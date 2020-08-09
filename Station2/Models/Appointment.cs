using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public class Appointment
    {
        [Required]
        [Key]
        public int AppointmentId { get; set; }
        
        [Required]
        [Display(Name = "Prepared By")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Invoice Date")]
        public DateTime InvoiceDate { get; set; }
        //[Required]
        //[Display(Name = "State")]
        //public InvoiceState InvoiceState { get; set; }
        //[Display(Name = "Invoice Total")]
        //public double? InvoiceTotal { get; set; }
    }
}
