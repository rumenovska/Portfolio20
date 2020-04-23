using Microsoft.AspNetCore.Identity;
using System;

namespace VehicleApp.DataAccess.IdentityData
{
    public class MyIdentityUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}