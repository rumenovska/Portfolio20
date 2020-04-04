using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleApp.Domain.Models;

namespace VehicleApp.DataAccess
{
    public class VehicleAppDbContext: DbContext
    {
        public VehicleAppDbContext (DbContextOptions options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
               .HasMany(v => v.Orders)
               .WithOne(o => o.Vehicle)
               .HasForeignKey(o => o.VehicleId);

            modelBuilder.Entity<Order>()
               .HasMany(o => o.Products)
               .WithOne(p => p.Order)
               .HasForeignKey(p => p.OrderId);

        }
    }
}
