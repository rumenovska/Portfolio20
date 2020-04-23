using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using VehicleApp.Domain.Models;

namespace VehicleApp.DataAccess.IdentityData
{
    public class DataInitializer
    {

        public static void SeedRoles(UserManager<MyIdentityUser> userManager, RoleManager<MyIdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("EmployeeUser").Result)
            {
                MyIdentityRole role = new MyIdentityRole();
                role.Name = "EmployeeUser";
                role.Description = "Perform normal operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Manager").Result)
            {
                MyIdentityRole role = new MyIdentityRole();
                role.Name = "Manager";
                role.Description = "Perform all the operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }

        public static void SeedUsers(UserManager<MyIdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("rumenov").Result == null)
            {
                MyIdentityUser user = new MyIdentityUser();
                user.UserName = "rumenov";
                user.Email = "rumenov@gmail.com";
                user.FullName = "Nancy Rmenov";
                user.BirthDate = new DateTime(1994, 8, 1);

                IdentityResult result = userManager.CreateAsync(user, "Rumonov123.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "EmployeeUser").Wait();
                }
            }


            if (userManager.FindByNameAsync("xhevo").Result == null)
            {
                MyIdentityUser user = new MyIdentityUser();
                user.UserName = "xhevo";
                user.Email = "xhevo@hotmail.com";
                user.FullName = "Xhevo Smith";
                user.BirthDate = new DateTime(1965, 1, 1);

                IdentityResult result = userManager.CreateAsync(user, "Xhevo123.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Manager").Wait();
                }
            }
        }

        public static void SeedData(VehicleAppDbContext context, RoleManager<MyIdentityRole> roleManager, UserManager<MyIdentityUser> userManager)
        {

            SeedRoles(userManager, roleManager);
            SeedUsers(userManager);
            SeedProducts(context);
        }

        public static void SeedProducts(VehicleAppDbContext dbContext)
        {
            //if (dbContext.Products.FirstOrDefault(p => p.ProductName == "Gorivo") == null)
            //{
            //    Product newProdcut = new Product
            //    {
            //        ProductName = "Gorivo",
            //}
                  //}
        }
    }
}

