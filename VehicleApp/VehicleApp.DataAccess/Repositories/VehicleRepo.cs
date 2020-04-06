using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleApp.DataAccess.Interfaces;
using VehicleApp.Domain.Models;


namespace VehicleApp.DataAccess.Repositories
{
    public class VehicleRepo : BaseRepo, IRepository<Vehicle>
    {

        public VehicleRepo(VehicleAppDbContext context) : base(context) { }
        public IEnumerable<Vehicle> GetAll()
        {
            return _context.Vehicles
                .Include(v => v.Orders);
        }

        public Vehicle GetById(int id)
        {
            return _context.Vehicles.Include(v=> v.Orders).FirstOrDefault(v => v.Id == id);
        }

        public int Insert(Vehicle entity)
        {
            _context.Add(entity);
            return _context.SaveChanges();
        }

        public int Update(Vehicle entity)
        {
            _context.Update(entity);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {

            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == id);

            if (vehicle == null)
                return -1;

            _context.Remove(vehicle);
            return _context.SaveChanges();
        }
    }
}
