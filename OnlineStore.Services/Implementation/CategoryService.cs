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
    public class CategoryService : ICategoryService
    {
        /// <summary>
        /// Returns details of a particular category.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<Category> GetCategoryAsync(int category, StoreContext context)
        {
            return await context.Categories.FirstOrDefaultAsync(c => c.Id == category);
        }

        /// <summary>
        /// Returns details of a particular category.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public Category GetCategory(int category, StoreContext context)
        {
            return context.Categories.FirstOrDefault(c => c.Id == category);
        }

        /// <summary>
        /// Returns details of all the categories.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<List<Category>> GetCategoriesAsync(StoreContext context)
        {
            return await context.Categories.ToListAsync();
        }

        /// <summary>
        /// Returns a list of all the products contained within a particular category.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task<List<Product>> GetProductsInCategory(int category, StoreContext context)
        {
            return context.Products.Where(p => p.Categories.Select(c => c.Id).Contains(category)).ToListAsync();
        }

        /// <summary>
        /// Returns all the categories considered 'top level', in that their parent category is the top category (the category with no parent).
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<List<Category>> GetTopLevelCategoriesAsync(StoreContext context)
        {
            // todo: this
            return await this.GetCategoriesAsync(context);
        }
    }
}
