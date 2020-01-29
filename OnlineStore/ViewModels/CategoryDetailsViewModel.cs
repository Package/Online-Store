using OnlineStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.ViewModels
{
    public class CategoryDetailsViewModel
    {
        public Category Category { get; set; }

        public List<Product> Products { get; set; }
    }
}