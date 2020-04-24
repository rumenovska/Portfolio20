using System.Collections.Generic;
using VehicleApp.Domain.Models;

namespace VehicleApp.WebModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public virtual List<Expense> Expenses { get; set; }
    }
}