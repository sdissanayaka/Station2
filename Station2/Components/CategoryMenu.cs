using Microsoft.AspNetCore.Mvc;
using Station2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station2.Components
{
    public class CategoryMenu: ViewComponent

    {
        //catrgoryrepository is passed into constructor injection
        private readonly IItemCategoryRepository _categoryRepository;
        public CategoryMenu(IItemCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
            //simply get a list of categories in tha database
        {
            var categories = _categoryRepository.AllCategories.OrderBy(c => c.CategoryName);
            return View(categories); //need to go to the database to get all the actegories
        }
    }
}
