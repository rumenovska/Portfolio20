using System;
using System.Collections.Generic;
using System.Text;
using VehicleApp.WebModels;

namespace VehicleApp.Services.Interfaces
{
    public interface IExpenceService
    {
        VehicleExpencesViewModel GetAllExpencesForVehicle(int vehicleId);
        //ExpenceViewModel GetExpenceById(int id);
        //int CreateExpence(ExpenceViewModel expence);
        //int UpdateExpence(ExpenceViewModel expence);
        //int RemoveExpence(int id);
    }
}
