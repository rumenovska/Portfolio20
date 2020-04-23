using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehicleApp.Domain.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string OrderType { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DateOfOrder { get; set; }
        [Required]
        public int TotalOrder { get; set; }

        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public virtual List<OrderProdutcs> OrderProdutcs { get; set; }
    }
}
