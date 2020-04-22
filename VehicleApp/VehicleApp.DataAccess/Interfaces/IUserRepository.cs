using System;
using System.Collections.Generic;
using System.Text;
using VehicleApp.Domain.Models;

namespace VehicleApp.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        User GetByUsernme(string username);
        User GetById(string id);
    }
}
