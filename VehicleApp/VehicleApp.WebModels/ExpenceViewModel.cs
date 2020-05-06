using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VehicleApp.WebModels
{
    public class ExpenceViewModel
    {
        public int Id { get; set; }

        [Required]
        public int Cost { get; set; }

        [Required]
        public string CostDescription { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }


        public int ExpenceTypeId { get; set; }

        public virtual ExpenceTypeViewModel ExpenceTypeViewModel { get; set; }

        public int VehicleId { get; set; }

        public virtual VehicleViewModel Vehicle { get; set; }
    }
}
