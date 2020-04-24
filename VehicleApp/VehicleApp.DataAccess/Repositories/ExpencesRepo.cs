using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleApp.DataAccess.Interfaces;
using VehicleApp.Domain.Models;

namespace VehicleApp.DataAccess.Repositories
{
    public class ExpencesRepo : BaseRepo, IRepository<Expenses>
    {
        public ExpencesRepo(VehicleAppDbContext context) : base(context) { }
       

        public IEnumerable<Expenses> GetAll()
        {
            return _context.Expenses
                .Include(e => e.Vehicle)
                .Include(e => e.Product);
        }

        public Expenses GetById(int id)
        {
            //return _context.Expenses
            //    .Include(e => e.Vehicle)
            //    .Include(e => e.Product)
            //    .FirstOrDefault(e => e.Id == id);

            return GetAll().FirstOrDefault(e => e.Id == id);
        }

        public int Insert(Expenses entity)
        {
            _context.Add(entity);
            return _context.SaveChanges();
        }

        public int Update(Expenses entity)
        {
            _context.Update(entity);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            Expenses expense = GetById(id);
            if(expense != null)
            {
                _context.Remove(expense);
                return _context.SaveChanges();
            }

            return -1;
        }
    }
}
