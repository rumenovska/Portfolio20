using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleApp.DataAccess.Repositories
{
    public class BaseRepo
    {
        protected readonly VehicleAppDbContext _context;
        public BaseRepo(VehicleAppDbContext context)
        {
            _context = context;
        }
    }
}
