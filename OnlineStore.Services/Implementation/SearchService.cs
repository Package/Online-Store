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
    public class SearchService : ISearchService
    {
        /// <summary>
        /// Performs a search on the products and returns those whose name matches the term searched for.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<List<Product>> SearchProducts(string searchTerm, StoreContext context)
        {
            return await context.Products.Where(p => p.Name.Contains(searchTerm) || p.DescriptionLong.Contains(searchTerm)).ToListAsync();
        }
    }
}
