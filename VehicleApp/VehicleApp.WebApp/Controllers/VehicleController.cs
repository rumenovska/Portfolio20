using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
           
           
            return View(vehicles);
        }
        

        public IActionResult AddVehicle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddVehicle(VehicleViewModel model)
        {

            var result = _vehicleService.CreateVehicle(model);
            if(result >= 0)
            {
                var message = "The Vehicle Was Successfully Added!";
                _toastNotification.AddSuccessToastMessage(message);
            }
            else
            {
                var message = "Something went wrong while adding vehicle";
                _toastNotification.AddErrorToastMessage(message);
            }
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
            var message = "The Vehicle Was Successfully Updated!";
            _toastNotification.AddSuccessToastMessage(message);
           return RedirectToAction("Vehicles", "Vehicle");
         
        }
        public IActionResult RemoveVehicle(int vehicleId)
        {
            var vehicle = _vehicleService.GetVehicleById(vehicleId);
            return View(vehicle);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult RemoveVehicle(VehicleViewModel model)
        {

            _vehicleService.RemoveVehicle(model.Id);
            var message = $"Vehicle is permanently removed!";
            _toastNotification.AddSuccessToastMessage(message);
            return RedirectToAction("Vehicles", "Vehicle");

        }
    }
}