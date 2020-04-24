using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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


        public AccountController(UserManager<MyIdentityUser> userManager,
           SignInManager<MyIdentityUser> loginManager,
           RoleManager<MyIdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.loginManager = loginManager;
            this.roleManager = roleManager;
        }


        [Authorize(Roles = Roles.Manager)]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                    return RedirectToAction("Index", "Home");
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
                    return RedirectToAction("Vehicles", "Vehicle");
                }

                ModelState.AddModelError("", "Invalid login!");
            }

            return View(obj);
        }


        public IActionResult Logout()
        {
            loginManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }


    }
}