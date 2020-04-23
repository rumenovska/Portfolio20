using Microsoft.AspNetCore.Identity;
using System;

namespace VehicleApp.DataAccess.IdentityData
{
    public class MyIdentityRole : IdentityRole
    {
        public string Description { get; set; }
    }
}