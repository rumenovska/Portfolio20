using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehicleApp.Domain.Models
{
    public class Expenses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public string CostDescription { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }
        public int ProductId { get; set; }

        public virtual List<Product> Products { get; set; }

        public int VehicleId { get; set; }

        public virtual List<Vehicle> Vehicles { get; set; }
        


    }
}
