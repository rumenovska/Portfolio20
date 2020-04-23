using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleApp.DataAccess.IdentityData
{
    public class MyIdentityUserStore : UserStore<MyIdentityUser>
    {
        public MyIdentityUserStore(DbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}
