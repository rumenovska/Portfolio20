using System;
using System.Collections.Generic;

namespace VehicleApp.WebModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string OrderType { get; set; }
        public string Description { get; set; }
        public DateTime DateOfOrder { get; set; }
        public int TotalOrder { get; set; }

        public int VehicleId { get; set; }
        public virtual VehicleViewModel Vehicle { get; set; }

        public virtual IEnumerable<ProductViewModel> Products { get; set; }
    }
}