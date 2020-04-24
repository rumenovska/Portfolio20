using System;
using System.Collections.Generic;
using System.Text;
using VehicleApp.WebModels;

namespace VehicleApp.Services.Interfaces
{
    public interface IExpenceService
    {
        IEnumerable<ExpenseViewModel> GetAllExpences();
        ExpenseViewModel GetExpenceById(int id);
        int CreateExpence(ExpenseViewModel expence);
        int UpdateExpence(ExpenseViewModel expence);
        int RemoveExpence(int id);
    }
}
