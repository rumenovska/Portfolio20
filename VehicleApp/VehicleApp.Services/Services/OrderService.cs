using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleApp.DataAccess.Interfaces;
using VehicleApp.Domain.Models;
using VehicleApp.Services.Interfaces;
using VehicleApp.WebModels;

namespace VehicleApp.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IRepository<Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public IEnumerable<OrderViewModel> GetAllOrders()
        {
            return _mapper.Map<List<OrderViewModel>>(_orderRepository.GetAll());
        }

        public OrderViewModel GetOrderById(int id)
        {
            return _mapper.Map<OrderViewModel>(_orderRepository.GetById(id));
        }
        public int CreateOrder(OrderViewModel order)
        {
            Order mappedOrder = _mapper.Map<Order>(order);
            return _orderRepository.Insert(mappedOrder);
        }
        
        public int UpdateOrder(OrderViewModel order)
        {
            Order mappedOrder = _mapper.Map<Order>(order);
            return _orderRepository.Update(mappedOrder);
        }
        public int RemoveOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}
