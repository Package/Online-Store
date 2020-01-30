using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Short Description")]
        public string DescriptionShort { get; set; }

        [Display(Name="Long Description")]
        public string DescriptionLong { get; set; }

        [Required]
        public DateTime Added { get; set; }

        [Required]
        [Display(Name="Quantity in Stock")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name="Price per Product")]
        public decimal Price { get; set; }

        public virtual List<Category> Categories { get; set; }
    }
}
