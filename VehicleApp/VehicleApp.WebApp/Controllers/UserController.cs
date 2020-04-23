using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Serilog;
using VehicleApp.Services.Interfaces;
using VehicleApp.WebModels;


namespace VehicleApp.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IToastNotification _toastNotification;
        public UserController(IUserService userService, IToastNotification toastNotification)
        {
            _userService = userService;
            _toastNotification = toastNotification;
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userService.Login(model);
                if (User.IsInRole("admin"))
                {
                    _toastNotification.AddSuccessToastMessage("You have successfully loged in!");


                    Log.Information($"User with username {model.Username} logged in as admin!");

                    return RedirectToAction("Register", "User");
                }
                Thread.Sleep(1000);
                _toastNotification.AddSuccessToastMessage("You have successfully loged in!");

                Log.Error($"User with username {model.Username} logged in as regular user!");

                return RedirectToAction("vehicles", "vehicle");
            }
            _toastNotification.AddWarningToastMessage("Username or password are incorect!");
            return View(model);
        }
        
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        
        public IActionResult Register(RegisterViewModel model)
        {
            _userService.Register(model);
            return RedirectToAction("vehicles", "vehicle");
        }


        public IActionResult Logout()
        {
            _userService.Logout();
            return RedirectToAction("index", "home");
        }
    }
}