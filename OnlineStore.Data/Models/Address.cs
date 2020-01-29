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
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string Line3 { get; set; }

        public string Line4 { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        public string Country { get; set; }

        public Customer Customer { get; set; }
    }
}
