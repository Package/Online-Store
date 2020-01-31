using OnlineStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Areas.Admin.ViewModels
{
    public class ManageProductViewModel
    {
        public Product Product { get; set; }

        public List<Category> Categories { get; set; }

        public int? MainCategory { get; set; }

        public int? SecondaryCategory { get; set; }
    }
}