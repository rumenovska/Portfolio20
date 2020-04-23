using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleApp.Domain.Models;

namespace VehicleApp.DataAccess
{
    public class VehicleAppDbContext: IdentityDbContext<User>
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

            // ADMIN ROLE ID
            string managerId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
                {
                    Id = managerId,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                }, 
            new IdentityRole
            {
                Id = userRoleId,
                Name = "user",
                NormalizedName = "USER"

            });

            var hasher = new PasswordHasher<User>();
            // SEEDING ADMIN USER WITHOUT ROLE
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = managerId,
                UserName = "manager",
                NormalizedUserName = "MANAGER",
                Email = "manager@mail.com",
                NormalizedEmail = "manager@mail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456Admin#"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = managerId,
                UserId = userRoleId

            });
        }
    }
}
