using System;
using System.Collections.Generic;
using System.Text;
using VehicleApp.WebModels;

namespace VehicleApp.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderViewModel> GetAllOrders();
        OrderViewModel GetOrderById(int id);
        int CreateOrder(OrderViewModel order);
        int UpdateOrder(OrderViewModel order);
        int RemoveOrder(int id);
    }
}
