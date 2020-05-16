using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Models
{
    public class MockCategoryRepository: IItemCategoryRepository
    {
        public IEnumerable<ItemCategory> AllCategories =>
           new List<ItemCategory>
           {
                new ItemCategory{CategoryId=1, CategoryName="Raw Material", CategoryDescription="Buy your raw materials"},
                new ItemCategory{CategoryId=2, CategoryName="Service", CategoryDescription="Get and enjoy the serivce"},
           };
    }
}
