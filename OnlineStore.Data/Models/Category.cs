using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Category Name")]
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public Category ParentCategory { get; set; }

        public virtual List<Product> Products  { get; set; }
    }
}
