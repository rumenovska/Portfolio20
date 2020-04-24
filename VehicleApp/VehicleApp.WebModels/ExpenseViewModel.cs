using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VehicleApp.WebModels
{
    public class ExpenseViewModel
    {
        public int Id { get; set; }

        [Required]
        public int Cost { get; set; }

        [Required]
        public string CostDescription { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }

        public int TotalCost { get; set; }

        public int ProductId { get; set; }

        public virtual List<Product> Products { get; set; }

        public int VehicleId { get; set; }

        public virtual List<Vehicle> Vehicles { get; set; }
    }
}
