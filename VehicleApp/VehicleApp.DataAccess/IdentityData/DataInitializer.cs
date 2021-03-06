﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using VehicleApp.DataAccess.Interfaces;
using VehicleApp.Domain.Models;


namespace VehicleApp.DataAccess.IdentityData
{
    public class DataInitializer : IDataInitializer
    {
        private readonly RoleManager<MyIdentityRole> roleManager;
        private readonly UserManager<MyIdentityUser> userManager;
        private readonly VehicleAppDbContext context;

        public DataInitializer(RoleManager<MyIdentityRole> roleManager, UserManager<MyIdentityUser> userManager, VehicleAppDbContext context)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.context = context;
        }

        public void InitializeData()
        {
            SeedRoles();
            SeedUsers();
            SeedExpenceTypes();
        }

        private void SeedRoles()
        {
            if (!roleManager.RoleExistsAsync("EmployeeUser").Result)
            {
                MyIdentityRole role = new MyIdentityRole
                {
                    Name = "EmployeeUser",
                    Description = "Perform normal operations."
                };
                _ = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Manager").Result)
            {
                MyIdentityRole role = new MyIdentityRole
                {
                    Name = "Manager",
                    Description = "Perform all the operations."
                };
                _ = roleManager.
                CreateAsync(role).Result;
            }
        }

        private void SeedUsers()
        {
            if (userManager.FindByNameAsync("rumenov").Result == null)
            {
                MyIdentityUser user = new MyIdentityUser
                {
                    UserName = "rumenov",
                    Email = "rumenov@gmail.com",
                    FullName = "Nancy Rmenov",
                    BirthDate = new DateTime(1994, 8, 1)
                };

                IdentityResult result = userManager.CreateAsync(user, "Rumonov123.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "EmployeeUser").Wait();
                }
            }


            if (userManager.FindByNameAsync("xhevo").Result == null)
            {
                MyIdentityUser user = new MyIdentityUser
                {
                    UserName = "xhevo",
                    Email = "xhevo@hotmail.com",
                    FullName = "Xhevo Smith",
                    BirthDate = new DateTime(1965, 1, 1)
                };

                IdentityResult result = userManager.CreateAsync(user, "Xhevo123.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Manager").Wait();
                }
            }
        }

        private void SeedExpenceTypes()
        {
            if (context.ExpenceTypes.FirstOrDefault(et => et.Name == "Fuel") == null)
            {
                ExpenceType FuelExpenceType = new ExpenceType
                {
                    Name = "Fuel"
                };
                context.ExpenceTypes.Add(FuelExpenceType);  
            }

            if (context.ExpenceTypes.FirstOrDefault(et => et.Name == "Oil") == null)
            {
                ExpenceType OilExpenceType = new ExpenceType
                {
                    Name = "Oil"
                };
                context.ExpenceTypes.Add(OilExpenceType);
            }
        }

                        //<option value = "ULTRA 100 RACE PRO" > ULTRA 100 RACE PRO</option>
                        //<option value = "ULTRA 95+ ЕCONOMY" > ULTRA 95+ ЕCONOMY</option>
                        //    <option value = "ULTRA DIESEL GREEN POWER" > ULTRA DIESEL GREEN POWER</option>
                        //    <option value = "ULTRA DIESEL BIO POWER" > ULTRA DIESEL BIO POWER</option>
                        //    <option value = "ULTRA DIESEL BIO POWER" > ULTRA DIESEL BIO POWER</option>
                        //    <option value = "ULTRA LPG PLUS" > ULTRA LPG PLUS</option>
                        //<option value = "ULTRA CNG" > ULTRA CNG</option>


    }
}

