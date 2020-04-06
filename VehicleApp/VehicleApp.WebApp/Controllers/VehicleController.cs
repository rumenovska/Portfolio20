using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using VehicleApp.Services.Interfaces;
using VehicleApp.WebModels;

namespace VehicleApp.WebApp.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IToastNotification _toastNotification;
        public VehicleController(IVehicleService vehicleService, IToastNotification toastNotification)
        {
            _vehicleService = vehicleService;
            _toastNotification = toastNotification;
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
        

        public IActionResult AddVehicle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddVehicle(VehicleViewModel model)
        {
            
            _vehicleService.CreateVehicle(model);
            return RedirectToAction("Vehicles", "Vehicle");
        }

        public IActionResult DetailsVehicle(int vehicleId)
        {

            var vehicle = _vehicleService.GetVehicleById(vehicleId);
            return View(vehicle);
        }
        public IActionResult ChangeVehicle(int vehicleId)
        {
            var vehicle = _vehicleService.GetVehicleById(vehicleId);
            return View(vehicle);
        }
        [HttpPost]
        public IActionResult ChangeVehicle(VehicleViewModel model)
        {
            
            _vehicleService.UpdateVehicle(model);
           return RedirectToAction("Vehicles", "Vehicle");
         
        }
        public IActionResult RemoveVehicle(int vehicleId)
        {
            var vehicle = _vehicleService.GetVehicleById(vehicleId);
            return View(vehicle);
        }
        [HttpPost]
        public IActionResult RemoveVehicle(VehicleViewModel model)
        {

            _vehicleService.RemoveVehicle(model.Id);
            return RedirectToAction("Vehicles", "Vehicle");

        }
    }
}