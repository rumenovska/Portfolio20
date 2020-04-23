using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleApp.DataAccess.IdentityData
{
    public class VehicleIdentityDbContext : IdentityDbContext<MyIdentityUser, MyIdentityRole, string>
    {
        public VehicleIdentityDbContext
           (DbContextOptions options)
            : base(options)
        {
            //nothing here
        }

    }
}
