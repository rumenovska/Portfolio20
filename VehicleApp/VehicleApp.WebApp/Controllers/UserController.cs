using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleApp.Services.Interfaces;
using VehicleApp.WebModels;

namespace VehicleApp.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            _userService.Login(model);
            if (User.IsInRole("admin"))
            {
                return RedirectToAction("register", "user");
            }
            return RedirectToAction("vehicles", "vehicle");
        }
        [Authorize(Roles = "user")]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "user")]
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