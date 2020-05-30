using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public class CategoryRepository: IItemCategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<ItemCategory> AllCategories => _appDbContext.ItemCategories;
    }
}
