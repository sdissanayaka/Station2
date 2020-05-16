using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public interface IItemMasterRepository
    {
        IEnumerable<ItemMaster> AllItems { get; }
        IEnumerable<ItemMaster> ItemsOfTheWeek { get; }
        ItemMaster GetItemById(int itemId);

    }
}
