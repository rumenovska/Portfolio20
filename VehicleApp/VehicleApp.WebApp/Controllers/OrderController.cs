using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using VehicleApp.Services.Interfaces;
using VehicleApp.WebModels;

namespace VehicleApp.WebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IToastNotification _toastNotification;
        public OrderController(IOrderService orderService, IProductService productService, IToastNotification toastNotification)
        {
            _orderService = orderService;
            _productService = productService;
            _toastNotification = toastNotification;
        }
        public IActionResult AddOrder()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddOrder(OrderViewModel orderModel)
        {
            _orderService.CreateOrder(orderModel);
      
            return RedirectToAction("vehicles", "vehicle");
        }
    }
}