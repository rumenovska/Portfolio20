using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleApp.Services.Interfaces;

namespace VehicleApp.WebApp.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        public IActionResult Vehicles()
        {
            var vehicles = _vehicleService.GetAllVehicles();
            foreach (var v in vehicles)
            {
                if (v.RegistrationExpiryDate == null || v.RegistrationExpiryDate < DateTime.Now)
                {
                    v.DisplayDate = "Vehicle Registration Expired";
                }
            }
            return View(vehicles);
        }
    }
}