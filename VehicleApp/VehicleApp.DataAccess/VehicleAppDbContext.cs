using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleApp.DataAccess.IdentityData;
using VehicleApp.Domain.Models;

namespace VehicleApp.DataAccess
{
    public class VehicleAppDbContext : VehicleIdentityDbContext
    {
        public VehicleAppDbContext(DbContextOptions<VehicleAppDbContext> options) : base(options) { }

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
                .HasMany(o => o.OrderProdutcs)
                .WithOne(po => po.Order)
                .HasForeignKey(po => po.OrderId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderProdutcs)
                .WithOne(po => po.Product)
                .HasForeignKey(po => po.ProductId);


        }
    }
}
