using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleApp.DataAccess.IdentityData;
using VehicleApp.Domain.Models;

namespace VehicleApp.DataAccess
{
    public class VehicleAppDbContext : IdentityDbContext<MyIdentityUser, MyIdentityRole, string>
    {
        public VehicleAppDbContext(DbContextOptions<VehicleAppDbContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Expense>()
                .HasOne(ex => ex.Vehicle)
                .WithMany(v => v.Expenses)
                .HasForeignKey(ex => ex.VehicleId);

            modelBuilder.Entity<Expense>()
               .HasOne(ex => ex.Product)
               .WithMany(p => p.Expenses)
               .HasForeignKey(ex => ex.ProductId);


        }
    }
}
