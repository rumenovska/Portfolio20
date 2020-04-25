using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using VehicleApp.DataAccess.IdentityData;
using VehicleApp.Domain.Constants;
using VehicleApp.WebModels;

namespace VehicleApp.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<MyIdentityUser> userManager;
        private readonly SignInManager<MyIdentityUser> loginManager;
        private readonly RoleManager<MyIdentityRole> roleManager;
        private readonly IToastNotification _toastNotification;


        public AccountController(UserManager<MyIdentityUser> userManager, SignInManager<MyIdentityUser> loginManager, RoleManager<MyIdentityRole> roleManager, IToastNotification toastNotification)
        {
            this.userManager = userManager;
            this.loginManager = loginManager;
            this.roleManager = roleManager;
            _toastNotification = toastNotification;
        }


        [Authorize(Roles = Roles.Manager)]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Manager)]
        public IActionResult Register(RegisterViewModel obj)
        {
            if (ModelState.IsValid)
            {
                MyIdentityUser user = new MyIdentityUser
                {
                    UserName = obj.UserName,
                    Email = obj.Email,
                    FullName = obj.FullName,
                    BirthDate = obj.BirthDate
                };

                IdentityResult result = userManager.CreateAsync (user, obj.Password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Roles.Employee).Wait();
                    _toastNotification.AddSuccessToastMessage("Employee Acconut Was Successfuly Registered!!!");
                    return RedirectToAction("Vehicles", "Vehicle");
                }
            }
            return View(obj);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var result = loginManager.PasswordSignInAsync
                (obj.UserName, obj.Password,
                  obj.RememberMe, false).Result;

                if (result.Succeeded)
                {
                   
                    _toastNotification.AddInfoToastMessage("Successfully logged in!");
                    return RedirectToAction("Vehicles", "Vehicle");
                }

                ModelState.AddModelError("", "Invalid login!");
            }

            return View(obj);
        }


        public IActionResult Logout()
        {
            loginManager.SignOutAsync().Wait();
            _toastNotification.AddInfoToastMessage("Successfully signed out!");
            return RedirectToAction("Login", "Account");
        }


    }
}