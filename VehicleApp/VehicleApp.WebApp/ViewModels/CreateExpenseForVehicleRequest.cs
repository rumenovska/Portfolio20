using System.Collections.Generic;

namespace VehicleApp.WebApp.ViewModels
{
    public class CreateExpenseForVehicleRequest
    {
        public int WehicleId { get; set; }
        public List<int> ExpenceTypeIds { get; set; }
    }
}
