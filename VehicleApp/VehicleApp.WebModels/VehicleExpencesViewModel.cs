using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleApp.WebModels
{
    public class VehicleExpencesViewModel
    {
        public int VehicleId { get; set; }
        public int TotalCost { get => Expences.Sum(e => e.Cost);}
        public List<ExpenceViewModel> Expences { get; set; }
    }
}
