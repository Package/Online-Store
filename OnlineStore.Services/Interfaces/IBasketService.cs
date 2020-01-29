using OnlineStore.Data.Database;
using OnlineStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Services.Interfaces
{
    public interface IBasketService
    {
        List<Product> GetProductsInBasket();
        void AddToBasket(Product product, int quantity = 1);
        void RemoveFromBasket(Product product);
        void UpdateQuantity(Product product, int quantity);
        void ClearBasket();
        decimal GetBasketTotal();
    }
}
