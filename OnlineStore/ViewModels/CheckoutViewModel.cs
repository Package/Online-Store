using OnlineStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.ViewModels
{
    public class CheckoutViewModel
    {
        public Address Address{ get; set; }

        public List<Product> ProductsInBasket { get; set; }
    }
}