using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Address Line 1")]
        public string Line1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string Line2 { get; set; }

        [Display(Name = "Address Line 3")]
        public string Line3 { get; set; }

        [Display(Name = "Address Line 4")]
        public string Line4 { get; set; }

        [Required]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        [Required]
        public string Country { get; set; }

        public Customer Customer { get; set; }
    }
}
