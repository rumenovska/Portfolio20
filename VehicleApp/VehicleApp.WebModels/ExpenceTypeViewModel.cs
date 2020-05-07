using System.Collections.Generic;
using VehicleApp.Domain.Models;

namespace VehicleApp.WebModels
{
    public class ExpenceTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Expence> Expenses { get; set; }
    }
}