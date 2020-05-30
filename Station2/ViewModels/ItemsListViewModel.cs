using Station2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.ViewModels
{
    public class ItemsListViewModel
    {
        public IEnumerable<ItemMaster> Items { get; set; }
        //public IEnumerable<ItemCategory> Categories { get; set; }

        public string CurrentCategory { get; set; }
    }
}
