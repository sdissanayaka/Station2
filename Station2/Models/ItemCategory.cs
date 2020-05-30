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
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public List<ItemMaster> Items { get; set; }

        
    }
}
