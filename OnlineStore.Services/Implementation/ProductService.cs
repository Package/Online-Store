using OnlineStore.Data.Database;
using OnlineStore.Data.Models;
using OnlineStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OnlineStore.Services.Implementation
{
    public class ProductService : IProductService
    {
        private ICategoryService categoryService { get; set; }

        public ProductService(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        /// <summary>
        /// Returns the details of a specific product.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<Product> GetProduct(int productId, StoreContext context)
        {
            return await context.Products.FirstOrDefaultAsync(p => p.Id == productId);
        }

        /// <summary>
        /// Returns a list of 'related products'. This is defined as any other products within the same category.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<List<Product>> GetRelatedProducts(int category, StoreContext context)
        {
            return await categoryService.GetProductsInCategory(category, context);
        }
    }
}
