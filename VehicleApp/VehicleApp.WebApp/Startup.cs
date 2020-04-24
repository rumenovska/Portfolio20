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
using Microsoft.Extensions.Logging;
using NToastNotify;
using VehicleApp.DataAccess;
using VehicleApp.DataAccess.IdentityData;
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

            //services.AddDbContext<VehicleAppDbContext>(opts => opts
            //   .UseSqlServer(Configuration.GetConnectionString("VehicleConnectionString")));

            services.AddIdentity<MyIdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.Password.RequireNonAlphanumeric = false;

            }).AddEntityFrameworkStores<VehicleAppDbContext>();
            services.AddTransient<IRepository<Vehicle>, VehicleRepo>();
            services.AddTransient<IRepository<Expenses>, ExpencesRepo>();
            services.AddTransient<IRepository<Product>, ProductRepo>();

            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<IExpenceService, ExpenceService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddAutoMapper();
            services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
            {
                ProgressBar = false,
                PositionClass = ToastPositions.TopRight,
                CloseButton = true
            });

            if (Configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                // use an in memory database instead of a real sql database
                services.AddDbContext<VehicleIdentityDbContext>(builder => builder.UseInMemoryDatabase("VehiclesDatabase"));
            }


            services.AddIdentity<MyIdentityUser, MyIdentityRole>()
                .AddEntityFrameworkStores<VehicleIdentityDbContext>()
                .AddUserStore<MyIdentityUserStore>()
                .AddDefaultTokenProviders();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            if (Configuration.GetValue<bool>("SeedDatabase"))
            {
                var serviceProvider = services.BuildServiceProvider();
                var context = serviceProvider.GetService<VehicleAppDbContext>();
                var roleManager = serviceProvider.GetService<RoleManager<MyIdentityRole>>();
                var userManager = serviceProvider.GetService<UserManager<MyIdentityUser>>();
                DataInitializer.SeedData(context, roleManager, userManager);
            }

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
            

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseNToastNotify();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=home}/{action=index}/{id?}");
            });


        }
    }
}
