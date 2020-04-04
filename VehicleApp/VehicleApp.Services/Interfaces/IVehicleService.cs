using System;
using System.Collections.Generic;
using System.Text;
using VehicleApp.WebModels;

namespace VehicleApp.Services.Interfaces
{
    public interface IVehicleService
    {
        IEnumerable<VehicleViewModel> GetAllVehicles();
        VehicleViewModel GetVehicleById(int id);
        int CreateVehicle(VehicleViewModel vehicle);
        int UpdateVehicle(VehicleViewModel vehicle);
        int RemoveVehicle(int id);
    }
}
