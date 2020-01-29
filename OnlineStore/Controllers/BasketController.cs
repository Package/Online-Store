using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Data.Database;
using OnlineStore.Data.Models;
using OnlineStore.Services.Interfaces;

namespace OnlineStore.Controllers
{
    public class BasketController : Controller
    {
        private readonly IProductService productService;
        private readonly IBasketService basketService;
        private readonly StoreContext context;

        public BasketController(IProductService productService, IBasketService basketService)
        {
            this.context = new StoreContext();
            this.productService = productService;
            this.basketService = basketService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(int product)
        {
            var productToAdd = await productService.GetProduct(product, context);
            if (productToAdd == null)
                return Redirect("~/");

            basketService.AddToBasket(productToAdd, 1);

            return RedirectToAction("Details");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Remove(int product)
        {
            var productToRemove = await productService.GetProduct(product, context);
            if (productToRemove == null)
                return Redirect("~/");

            basketService.RemoveFromBasket(productToRemove);

            return RedirectToAction("Details");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Clear()
        {
            basketService.ClearBasket();

            return RedirectToAction("Details");
        }

        [HttpGet]
        public ActionResult Details()
        {
            var productsInBasket = basketService.GetProductsInBasket();

            return View(productsInBasket);
        }
    }
}
