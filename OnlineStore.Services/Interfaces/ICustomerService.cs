using OnlineStore.Data.Database;
using OnlineStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerByName(string userName, StoreContext context);
    }
}
