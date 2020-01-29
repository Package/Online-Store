using OnlineStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.ViewModels
{
    public class SearchViewModel
    {
        public string SearchTerm { get; set; }

        public List<Product> Products { get; set; }
    }
}