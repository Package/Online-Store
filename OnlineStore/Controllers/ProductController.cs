using OnlineStore.Data.Database;
using OnlineStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductService productService;
        private StoreContext context;

        public ProductController(IProductService productService)
        {
            this.context = new StoreContext();
            this.productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var product = await productService.GetProduct(id, context);
            //var relatedProducts = await productService.GetRelatedProducts(categoryId, context);

            return View(product);
        }
    }
}