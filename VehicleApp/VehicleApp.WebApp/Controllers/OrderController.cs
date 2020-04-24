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
        private readonly IExpenceService _orderService;
        private readonly IProductService _productService;
        private readonly IToastNotification _toastNotification;
        public OrderController(IExpenceService orderService, IProductService productService, IToastNotification toastNotification)
        {
            _orderService = orderService;
            _productService = productService;
            _toastNotification = toastNotification;
        }
    }
}