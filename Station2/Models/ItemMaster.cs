using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public class ItemMaster
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public bool IsItemOfTheWeek { get; set; }
        public int CategoryId { get; set; }
        //public string CategoryName { get; set; }
        public ItemCategory CategoryName { get; set; }




    }
}
