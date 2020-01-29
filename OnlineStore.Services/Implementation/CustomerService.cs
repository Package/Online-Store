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
    public class CustomerService : ICustomerService
    {
        /// <summary>
        /// Returns details of a customer based on their user name.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<Customer> GetCustomerByName(string userName, StoreContext context)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}
