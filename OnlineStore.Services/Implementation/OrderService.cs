using OnlineStore.Data.Database;
using OnlineStore.Data.Models;
using OnlineStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace OnlineStore.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IBasketService basketService;

        public OrderService(IBasketService basketService)
        {
            this.basketService = basketService;
        }

        /// <summary>
        /// Creates an order given the customer details, their delivery address and the total of the 
        /// products within the basket.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public Order CreateOrder(Customer customer, Address address)
        {
            var basketTotal = basketService.GetBasketTotal();

            var order = new Order { Customer = customer, DeliveryAddress = address, OrderTime = DateTime.Now, Total = basketTotal };

            return order;
        }

        /// <summary>
        /// Gets a list of the orders a provided customer has made.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<List<Order>> GetOrdersForCustomer(Customer customer, StoreContext context)
        {
            return await context.Orders.Where(o => o.Customer == customer).OrderByDescending(o => o.OrderTime).ToListAsync();
        }

        /// <summary>
        /// Saves an order record to the database.
        /// </summary>
        /// <param name="order"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task SaveOrder(Order order, StoreContext context)
        {
            context.Orders.AddOrUpdate(o => o.Id, order);
            await context.SaveChangesAsync();
        }
    }
}
