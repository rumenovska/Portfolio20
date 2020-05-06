using System;
using System.Collections.Generic;
using System.Text;
using VehicleApp.WebModels;

namespace VehicleApp.Services.Interfaces
{
    public interface IExpenceTypeService
    {
        IEnumerable<ExpenceTypeViewModel> GetAllExpenceTypes();
        ExpenceTypeViewModel GetExpenceTypeById(int id);
        int CreateExpenceType(ExpenceTypeViewModel expenceType);
        int UpdateExpenceType(ExpenceTypeViewModel expenceType);
        int RemoveExpenceType(int id);
    }
}
