using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleApp.Domain.Models
{
    public class User: IdentityUser
    {
        public string FullName { get; set; }
    }
}
