using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VehicleApp.Domain.Models;

namespace VehicleApp.WebModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        public string VehicleRegisteredNum { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string VehicleType { get; set; }
        public string Directorate { get; set; }
        public string EngineNum { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FirstRegistration { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RegistrationExpiryDate { get; set; }
        public bool Malfunction { get; set; }
        public bool Loan { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string DisplayDate { get; set; }
        public virtual List<Expence> Expenses { get; set; }

        public bool IsExpiredRegistration(DateTime regExpireDate)
        {
                if (regExpireDate == null || regExpireDate < DateTime.Now)
                {
                    DisplayDate = "Vehicle Registration Expired";
                    return true;
                }

            return false;
        }
    }
}
