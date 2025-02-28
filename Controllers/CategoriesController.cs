﻿using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = Categoriesrepository.GetCategories();
            return View(categories);
        }
        public IActionResult Edit(int? id)
        {
			ViewBag.Action = "edit";
			var category = Categoriesrepository.GetCategoryByID(id.HasValue?id.Value:0);
            return View(category);
        }
        
        
        [HttpPost]
		public IActionResult Edit(Category category)
		{
            if(ModelState.IsValid)
            {
				Categoriesrepository.UpdateCategory(category.CategoryId, category);

				return RedirectToAction(nameof(Index));
			}
            return View(category);
		}


		public IActionResult Add()
		{
			ViewBag.Action="add";
			return View();
		}
		[HttpPost]
		public IActionResult Add(Category category)
		{
			if (ModelState.IsValid)
			{
				Categoriesrepository.AddCategory(category);

				return RedirectToAction(nameof(Index));
			}
			return View();
		}


		public IActionResult DeleteCategory(int categoryId) {
			Categoriesrepository.DelelteCategory(categoryId);
			return RedirectToAction(nameof(Index)); 
		}
	}
}
