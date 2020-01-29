using OnlineStore.Data.Database;
using OnlineStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProduct(int productId, StoreContext context);
        Task<List<Product>> GetRelatedProducts(int productId, StoreContext context);
    }
}
