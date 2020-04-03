using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleApp.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderType { get; set; }
        public string Description { get; set; }
        public DateTime DateOfOrder { get; set; }
        public int TotalOrder { get; set; }

        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}
