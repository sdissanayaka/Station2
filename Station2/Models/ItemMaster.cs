using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public class ItemMaster
    {
        [Key]
        public int ItemId { get; set; }
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }
        public decimal Price { get; set; }
        public string UOM { get; set; }
        [Display(Name = "Stock Quantity")]
        public int StockQuantity { get; set; }
        public bool InStock { get; set; }

        [ForeignKey("CategoryId")]
        public ItemCategory Category { get; set; }




    }
}
