using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Enums
{
    public enum PaymentStatus
    {
        //[Display(Name = "Payment Completed")]
        PaymentCompleted,
        //[Display(Name = "More Installmets to pay")]
        MoreToPay
    }
}
