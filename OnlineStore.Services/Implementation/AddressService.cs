using OnlineStore.Data.Database;
using OnlineStore.Data.Models;
using OnlineStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Services.Implementation
{
    public class AddressService : IAddressService
    {
        /// <summary>
        /// Returns all the delivery addresses associated with the provided customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<List<Address>> GetAddressesForCustomer(Customer customer, StoreContext context)
        {
            return await context.Addresses.Where(a => a.Customer == customer).ToListAsync();
        }

        /// <summary>
        /// Saves an address to the database.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task SaveAddress(Address address, StoreContext context)
        {
            context.Addresses.AddOrUpdate(a => a.Id, address);
            await context.SaveChangesAsync();
        }
    }
}
