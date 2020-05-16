using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public interface IItemCategoryRepository
    {
        IEnumerable<ItemCategory> AllCategories { get; }

    }
}
