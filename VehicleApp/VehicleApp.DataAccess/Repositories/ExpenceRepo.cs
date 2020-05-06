using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleApp.DataAccess.Interfaces;
using VehicleApp.Domain.Models;

namespace VehicleApp.DataAccess.Repositories
{
    public class ExpenceRepo : BaseRepo, IRepository<Expence>
    {
        public ExpenceRepo(VehicleAppDbContext context) : base(context) { }
       

        public IEnumerable<Expence> GetAll()
        {
            return _context.Expenses
                .Include(e => e.Vehicle)
                .Include(e => e.ExpenceType);
        }

        public Expence GetById(int id)
        {
            return GetAll().FirstOrDefault(e => e.Id == id);
        }

        public int Insert(Expence entity)
        {
            _context.Add(entity);
            return _context.SaveChanges();
        }

        public int Update(Expence entity)
        {
            _context.Update(entity);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            Expence expense = GetById(id);
            if(expense != null)
            {
                _context.Remove(expense);
                return _context.SaveChanges();
            }

            return -1;
        }
    }
}
