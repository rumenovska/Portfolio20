using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NToastNotify;
using VehicleApp.DataAccess;
using VehicleApp.DataAccess.Interfaces;
using VehicleApp.DataAccess.Repositories;
using VehicleApp.Domain.Models;
using VehicleApp.Services.Interfaces;
using VehicleApp.Services.Services;


namespace VehicleApp.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<VehicleAppDbContext>(opts => opts
               .UseSqlServer(Configuration.GetConnectionString("VehicleConnectionString")));
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.Password.RequireNonAlphanumeric = false;

            });
            services.AddTransient<IRepository<Vehicle>, VehicleRepo>();
            services.AddTransient<IRepository<Order>, OrderRepo>();
            services.AddTransient<IRepository<Product>, ProductRepo>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUserService, UserService>();
            services.AddAutoMapper();
            services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
            {
                ProgressBar = false,
                PositionClass = ToastPositions.TopRight,
                CloseButton = true
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseNToastNotify();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Vehicle}/{action=Vehicles}/{id?}");
            });
        }
    }
}
