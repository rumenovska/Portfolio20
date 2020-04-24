using System.Collections.Generic;
using VehicleApp.Domain.Models;

namespace VehicleApp.WebModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int ExpenceId { get; set; }
        public virtual Expenses Expence { get; set; }
        public virtual List<Expenses> Expenses { get; set; }
    }
}