using OnlineStore.Data.Database;
using OnlineStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Services.Interfaces
{
    public interface IOrderService
    {
        Order CreateOrder(Customer customer, Address address);
        Task SaveOrder(Order order, StoreContext context);
        Task<List<Order>> GetOrdersForCustomer(Customer customer, StoreContext context);
    }
}
