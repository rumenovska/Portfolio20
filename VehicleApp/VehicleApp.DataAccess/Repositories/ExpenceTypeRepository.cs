using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleApp.DataAccess.Interfaces;
using VehicleApp.Domain.Models;

namespace VehicleApp.DataAccess.Repositories
{
    public class ExpenceTypeRepository: BaseRepo, IRepository<ExpenceType>
    {
        public ExpenceTypeRepository(VehicleAppDbContext context) : base(context) { }

        public IEnumerable<ExpenceType> GetAll()
        {
            return _context.ExpenceTypes
                .Include(p => p.Expenses);
                
        }

        public ExpenceType GetById(int id)
        {
            return _context.ExpenceTypes
                .Include(p=> p.Expenses)
                .FirstOrDefault(p => p.Id == id);
                
        }

        public int Insert(ExpenceType entity)
        {
            _context.Add(entity);
            return _context.SaveChanges();
        }

        public int Update(ExpenceType entity)
        {
            _context.Update(entity);
            return _context.SaveChanges();
        }
        public int Delete(int id)
        {
            ExpenceType expenceType = GetById(id);

            if(expenceType != null)
            {
                _context.Remove(expenceType);
                return _context.SaveChanges();
            }

            return -1;
        }
    }
}
