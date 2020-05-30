using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Station2.Models;
using Station2.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Station2.Controllers
{
    public class ItemMasterCustomerController : Controller
    {
        private readonly IItemMasterRepository _itemRepository;
        private readonly IItemCategoryRepository _categoryRepository;
        //to give access to repository
        public ItemMasterCustomerController(IItemMasterRepository itemRepository, IItemCategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
            //setting local repositories to the one that is going to injected
        }
        //now we have access model classess in the controller  
        // GET: /<controller>/
        //public IActionResult List()
        //{
        //ViewBag.CurrentCategory = "Cheese cakes";
        //ItemsListViewModel itemsListViewModel = new ItemsListViewModel();
        //itemsListViewModel.Items = _itemRepository.AllItems;

        //itemsListViewModel.CurrentCategory = "Cheese cakes";
        //return View(itemsListViewModel);
        //return View(_itemRepository.AllItems);
        //}
        /*public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();

            return View(pie);
        }*/
        public ViewResult List(string category)
        {
            IEnumerable<ItemMaster> items;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                items = _itemRepository.AllItems.OrderBy(p => p.ItemId);
                currentCategory = "All Items";
            }
            else
            {
                items = _itemRepository.AllItems.Where(p => p.CategoryName.CategoryName == category)
                    .OrderBy(p => p.ItemId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new ItemsListViewModel
            {
                Items = items,
                CurrentCategory = currentCategory
            });
        }


        public IActionResult Details(int id)
        {
            var item = _itemRepository.GetItemById(id);
            if (item == null)
                return NotFound();

            return View(item);
        }
    }
}

