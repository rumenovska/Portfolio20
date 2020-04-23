using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleApp.DataAccess.Interfaces;
using VehicleApp.Domain.Models;

namespace VehicleApp.DataAccess.Repositories
{
    public class ProductRepo: BaseRepo, IRepository<Product>
    {
        public ProductRepo(VehicleAppDbContext context) : base(context) { }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products
                .Include(p => p.OrderProdutcs);
                
        }

        public Product GetById(int id)
        {
            return _context.Products
                .Include(p=> p.OrderProdutcs)
                .FirstOrDefault(p => p.Id == id);
                
        }

        public int Insert(Product entity)
        {
            _context.Add(entity);
            return _context.SaveChanges();
        }

        public int Update(Product entity)
        {
            _context.Update(entity);
            return _context.SaveChanges();
        }
        public int Delete(int id)
        {
            Product product = GetById(id);

            if(product != null)
            {
                _context.Remove(product);
                return _context.SaveChanges();
            }

            return -1;
        }
    }
}
