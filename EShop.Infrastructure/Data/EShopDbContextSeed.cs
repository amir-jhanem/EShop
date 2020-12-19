using EShop.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Infrastructure.Data
{
    public class EShopDbContextSeed
    {
        public static async Task SeedAsync(IServiceProvider services, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            var eshopDbContext = services.GetRequiredService<EShopDbContext>();
            try
            {
                eshopDbContext.Database.Migrate();
                eshopDbContext.Database.EnsureCreated();

                // products
                await SeedProductsAsync(eshopDbContext);

                // roles
                await SeedRolesAsync(services);

                // admins
                await SeedAdminAsync(services);

                // customers
                await SeedCustomersAsync(services);
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<EShopDbContext>();
                    log.LogError(exception.Message);
                    await SeedAsync(services, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static async Task SeedProductsAsync(EShopDbContext eshopDbContext)
        {
            if (eshopDbContext.Products.Any())
                return;

            var products = new List<Product>
            {
                new Product()
                {
                    Name = "Kindle - Black",
                    ImageFile = "https://picsum.photos/id/367/200/200",
                    UnitPrice = 150,
                    UnitsInStock = 10
                },
                new Product()
                {
                    Name = "Laptop",
                    ImageFile = "https://picsum.photos/id/180/200/200",
                    UnitPrice = 200,
                    UnitsInStock = 5
                },
                new Product()
                {
                    Name = "Mac Collection",
                    ImageFile = "https://picsum.photos/id/201/200/200",
                    UnitPrice = 900,
                    UnitsInStock = 6
                },
                new Product()
                {
                    Name = "Camera",
                    ImageFile = "https://picsum.photos/id/250/200/200",
                    UnitPrice = 1000,
                    UnitsInStock = 20
                }
            };

            eshopDbContext.Products.AddRange(products);
            await eshopDbContext.SaveChangesAsync();
        }

        private static async Task SeedCustomersAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

            var user = new IdentityUser { UserName = "amir.jhanem93@gmail.com", Email = "amir.jhanem93@gmail.com" };
            await userManager.CreateAsync(user, "123456");
        }

        private static async Task SeedAdminAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

            var user = new IdentityUser { UserName = "admin@example.com", Email = "admin@example.com" };
            var result = await userManager.CreateAsync(user, "123456");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }

        private static async Task SeedRolesAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            var role = new IdentityRole { Name = "Admin" };
            await roleManager.CreateAsync(role);
        }
    }
}
