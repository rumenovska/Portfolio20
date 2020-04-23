using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleApp.DataAccess.Interfaces;
using VehicleApp.Domain.Models;

namespace VehicleApp.DataAccess.Repositories
{
    public class OrderRepo : BaseRepo, IRepository<Order>
    {
        public OrderRepo(VehicleAppDbContext context) : base(context) { }
       

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders
                .Include(o => o.OrderProdutcs);
        }

        public Order GetById(int id)
        {
            return _context.Orders
                .Include(o => o.OrderProdutcs)
                .FirstOrDefault(o => o.Id == id);
        }

        public int Insert(Order entity)
        {
            _context.Add(entity);
            return _context.SaveChanges();
        }

        public int Update(Order entity)
        {
            _context.Update(entity);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            Order order = GetById(id);
            if(order != null)
            {
                _context.Remove(order);
                return _context.SaveChanges();
            }

            return -1;
        }
    }
}
