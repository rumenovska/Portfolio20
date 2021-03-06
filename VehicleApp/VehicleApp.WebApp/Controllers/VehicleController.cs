﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using VehicleApp.Domain.Constants;
using VehicleApp.Services.Interfaces;
using VehicleApp.WebApp.ViewModels;
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

        [Authorize(Roles = Roles.ManagerAndEmployee)]
        public IActionResult Vehicles()
        {
            var vehicles = _vehicleService.GetAllVehicles();


            return View(vehicles);
        }

        [Authorize]
        public IActionResult AddVehicle()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddVehicle(VehicleViewModel model)
        {

            var result = _vehicleService.CreateVehicle(model);
            if (result >= 0)
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

        [Authorize]
        public IActionResult DetailsVehicle(int vehicleId)
        {

            var vehicle = _vehicleService.GetVehicleById(vehicleId);
            return View(vehicle);
        }

        [Authorize(Roles = Roles.Manager)]
        public IActionResult ChangeVehicle(int vehicleId)
        {
            var vehicle = _vehicleService.GetVehicleById(vehicleId);
            return View(vehicle);
        }

        
        [HttpPost]
        [Authorize(Roles = Roles.Manager)]
        public IActionResult ChangeVehicle(VehicleViewModel model)
        {

            _vehicleService.UpdateVehicle(model);
            var message = "The Vehicle Was Successfully Updated!";
            _toastNotification.AddSuccessToastMessage(message);
            return RedirectToAction("Vehicles", "Vehicle");

        }

        [Authorize(Roles = Roles.Manager)]
        public IActionResult RemoveVehicle(int vehicleId)
        {
            var vehicle = _vehicleService.GetVehicleById(vehicleId);
            return View(vehicle);
        }

        [Authorize(Roles = Roles.Manager)]
        [HttpPost]
        public IActionResult RemoveVehicle(VehicleViewModel model)
        {

            _vehicleService.RemoveVehicle(model.Id);
            var message = $"Vehicle is permanently removed!";
            _toastNotification.AddSuccessToastMessage(message);
            return RedirectToAction("Vehicles", "Vehicle");

        }

        //[HttpGet("/vehicles/{vehicleId:min(1)/expense}/expense")]
        //public IActionResult CreateExpenseForVehicle(int vehicleId)
        //{
        //    return View();
        //}

        //[HttpPost("/vehicles/{vehicleId:min(1)/expense}/expense")]
        //public IActionResult CreateExpenseForVehicle(int vehicleId, CreateExpenseForVehicleRequest model)
        //{
        //    return View();
        //}
    }
}