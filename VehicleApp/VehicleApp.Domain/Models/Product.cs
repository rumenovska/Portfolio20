﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehicleApp.Domain.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Description { get; set; }
        public int ExpenceId { get; set; }
        public virtual Expenses Expence { get; set; }
        public virtual List<Expenses> Expenses { get; set; }

    }
}
