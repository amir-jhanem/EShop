using AutoMapper;
using EShop.Application.Interfaces;
using EShop.Application.Services;
using EShop.Core.Configuration;
using EShop.Core.Interfaces;
using EShop.Core.Repositories;
using EShop.Core.Repositories.Core;
using EShop.Infrastructure.Data;
using EShop.Infrastructure.Logging;
using EShop.Infrastructure.Repository;
using EShop.Infrastructure.Repository.Base;
using EShop.Web.Interfaces;
using EShop.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web
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
            // eshop dependencies
            ConfigureEShopServices(services);

            services.AddRazorPages()
                .AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

        public void ConfigureEShopServices(IServiceCollection services)
        {
            // Add Core Layer
            services.Configure<EShopSettings>(Configuration);

            // Add Infrastructure Layer
            ConfigureDatabases(services);
            ConfigureIdentity(services);

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductRepository, ProductRepository>();

            // Add Application Layer
            services.AddScoped<IProductService, ProductService>();

            // Add Web Layer
            services.AddAutoMapper(typeof(Startup)); // Add AutoMapper
            services.AddScoped<IProductPageService, ProductPageService>();

            // Add Miscellaneous
            services.AddHttpContextAccessor();
        }

        public void ConfigureDatabases(IServiceCollection services)
        {
            services.AddDbContext<EShopDbContext>(c =>
                c.UseSqlite(Configuration.GetConnectionString("EShopDbContextConnection"), x => x.MigrationsAssembly("EShop.Web")));
        }

        public void ConfigureIdentity(IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<EShopDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });
        }
    }
}
