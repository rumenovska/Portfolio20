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
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Expenses>()
            // .HasMany(e => e.Products)
            // .WithMany(p => p.Expences)
            // .Map(cs =>
            // {
            //    cs.MapLeftKey("BookId");
            //    cs.MapRightKey("CategoryId");
            //    cs.ToTable("BookCategories");
            // });
        }
    }
}
