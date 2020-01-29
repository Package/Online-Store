using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public decimal Total { get; set; }

        public Customer Customer { get; set; }

        public DateTime OrderTime { get; set; }

        public Address DeliveryAddress { get; set; }
    }
}
