using OnlineStore.Data.Database;
using OnlineStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Services.Interfaces
{
    public interface ISearchService
    {
        Task<List<Product>> SearchProducts(string searchTerm, StoreContext context);
    }
}
