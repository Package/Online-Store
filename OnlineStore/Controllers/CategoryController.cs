using OnlineStore.Data.Database;
using OnlineStore.Services.Interfaces;
using OnlineStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService categoryService;
        private StoreContext context;

        public CategoryController(ICategoryService categoryService)
        {
            this.context = new StoreContext();
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var categories = await categoryService.GetCategoriesAsync(context);
            return View(categories);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var category = await categoryService.GetCategoryAsync(id, context);
            var products = await categoryService.GetProductsInCategory(id, context);

            var viewModel = new CategoryDetailsViewModel { Category = category, Products = products };

            return View(viewModel);
        }
    }
}