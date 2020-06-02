using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public class ItemRepository: IItemMasterRepository
    {
        private readonly AppDbContext _appDbContext;

        public ItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<ItemMaster> AllItems
        {
            get
            {
                return _appDbContext.ItemMaster.Include(c => c.Category);
            }
        }
        public IEnumerable<ItemMaster> ItemsOfTheWeek
        {
            get
            {
                return _appDbContext.ItemMaster.Include(c => c.Category).Where(p => p.IsItemOfTheWeek);
            }
        }
        public ItemMaster GetItemById(int itemId)
        {
            return _appDbContext.ItemMaster.FirstOrDefault(p => p.ItemId == itemId);
        }
    }
}
