using OnlineStore.Data.Models;
using OnlineStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace OnlineStore.Services.Implementation
{
    public class BasketService : IBasketService
    {
        private HttpSessionState CurrentSession { get { return HttpContext.Current.Session; } }

        private IProductService productService;

        private const string BasketKey = "BasketProducts";

        public BasketService(IProductService productService)
        {
            this.productService = productService;
        }

        public void AddToBasket(Product product, int quantity = 1)
        {
            var basket = this.GetProductsInBasket();
            basket.Add(product);

            CurrentSession[BasketKey] = basket;
        }

        public List<Product> GetProductsInBasket()
        {
            var itemsInBasket = (List<Product>)CurrentSession[BasketKey] ?? new List<Product>();
            return itemsInBasket;
        }

        public void RemoveFromBasket(Product product)
        {
            var basket = this.GetProductsInBasket();
            basket.RemoveAll(i => i.Id == product.Id);

            CurrentSession[BasketKey] = basket;
        }

        public void UpdateQuantity(Product product, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
