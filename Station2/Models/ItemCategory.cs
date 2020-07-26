using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public class ItemCategory
    {
        [Key]
        public int CategoryId { get; set; }
        [Display(Name = "Category Name")]

        public string CategoryName { get; set; }
        [Display(Name = "Category Description")]

        public string CategoryDescription { get; set; }
        public List<ItemMaster> Items { get; set; }

        
    }
}
