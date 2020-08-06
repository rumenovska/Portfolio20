using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using VehicleApp.Domain.Constants;
using VehicleApp.Domain.Models;
using VehicleApp.Services.Interfaces;
using VehicleApp.WebModels;

namespace VehicleApp.WebApp.Controllers
{
    public class ExpenceTypeController : Controller
    {
        private readonly IExpenceTypeService _expenceTypeService;
        private readonly IToastNotification _toastNotification;
        public ExpenceTypeController(IExpenceTypeService expenceTypeService, IToastNotification toastNotification)
        {
            _expenceTypeService = expenceTypeService;
            _toastNotification = toastNotification;
        }
        [Authorize(Roles = Roles.Manager)]
        public IActionResult AddExpenceType()
        {
            return View();
        }

        [Authorize(Roles = Roles.Manager)]
        [HttpPost]
        public IActionResult AddExpenceType(ExpenceTypeViewModel model)
        {
  
           var result = _expenceTypeService.CreateExpenceType(model);
            if (result >= 0)
            {
                
                _toastNotification.AddSuccessToastMessage("Expence Type Was Successfully Added!");
            }
            else
            {

                _toastNotification.AddErrorToastMessage("Something went wrong while adding expence type");
            }
            return RedirectToAction("vehicles","vehicle");
        }

        [Authorize(Roles = Roles.Manager)]
        public IActionResult AllExpenceTypes()
        {
            var expences = _expenceTypeService.GetAllExpenceTypes();

            return View(expences);
        }

        [Authorize(Roles = Roles.Manager)]
        public IActionResult UpdateExpenceType(int expenceTypeId)
        {
            var expence = _expenceTypeService.GetExpenceTypeById(expenceTypeId);
            return View(expence);
        }

        [Authorize(Roles = Roles.Manager)]
        [HttpPost]
        public IActionResult UpdateExpenceType(ExpenceTypeViewModel model)
        {
            _expenceTypeService.UpdateExpenceType(model);
            _toastNotification.AddSuccessToastMessage("Expence Type Was Successfully Updated!");
            return RedirectToAction("allexpencetypes", "expencetype");
        }

        [Authorize(Roles = Roles.Manager)]
        public IActionResult RemoveExpenceType(int expenceTypeId)
        {
            var expence = _expenceTypeService.GetExpenceTypeById(expenceTypeId);
            return View(expence);
        }


        [Authorize(Roles = Roles.Manager)]
        [HttpPost]
        public IActionResult RemoveExpenceType(ExpenceTypeViewModel model)
        {
            _expenceTypeService.RemoveExpenceType(model.Id);
            _toastNotification.AddSuccessToastMessage("Expence Type Was Successfully Removed!");
            return RedirectToAction("allexpencetypes", "expencetype");
        }

    }
}