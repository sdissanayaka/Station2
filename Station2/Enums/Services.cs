using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Enums
{
    public enum Services
    {
        [Display(Name = "Full Services")]
        FullService,
        [Display(Name = "Body wash")]
        BodyWash,
        [Display(Name = "Replacing Spare Parts and Engine Oil")]
        Replacement,
        [Display(Name = "Changing Seat Covers")]
        SeatCover,
        [Display(Name = "Changing Tyres")]
        ChangeTyres,

    }
}
