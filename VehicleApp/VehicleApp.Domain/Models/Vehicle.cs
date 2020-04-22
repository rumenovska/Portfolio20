using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VehicleApp.Domain.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Required]
        public string VehicleRegisteredNum { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string VehicleType { get; set; }
        [Required]
        public string Directorate { get; set; }
        [Required]
        public string EngineNum { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FirstRegistration { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? RegistrationExpiryDate { get; set; }
        [Required]
        public bool Malfunction { get; set; }
        [Required]
        public bool Loan { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeEmail { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
