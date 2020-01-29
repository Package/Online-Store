using OnlineStore.Data.Database;
using OnlineStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryAsync(int category, StoreContext context);
        Category GetCategory(int category, StoreContext context);
        Task<List<Category>> GetCategoriesAsync(StoreContext context);
        Task<List<Category>> GetTopLevelCategoriesAsync(StoreContext context);
        Task<List<Product>> GetProductsInCategory(int category, StoreContext context);
    }
}
