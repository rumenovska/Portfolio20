using System;
using System.Collections.Generic;

namespace VehicleApp.WebApp.ViewModels
{
    public class CreateExpenseForVehicleRequest
    {
        public int VehicleId { get; set; }
        public int ExpenceTypeId { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

    }
}
