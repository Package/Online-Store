using Microsoft.AspNet.Identity.EntityFramework;
using OnlineStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Database
{
    // Migrations Docs:
    // https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/migrations/ 
    public class StoreContext : IdentityDbContext<Customer>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }

        public StoreContext()
            : base("DefaultConnection", throwIfV1Schema: false) {}

        public static StoreContext Create()
        {
            return new StoreContext();
        }
    }
}
