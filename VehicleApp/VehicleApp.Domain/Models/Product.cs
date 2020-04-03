using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleApp.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
