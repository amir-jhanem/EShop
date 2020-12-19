using EShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Infrastructure.Data
{
    public class EShopDbContextSeed
    {
        public static async Task SeedAsync(EShopDbContext eshopDbContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                eshopDbContext.Database.Migrate();
                eshopDbContext.Database.EnsureCreated();

                // products
                await SeedProductsAsync(eshopDbContext);
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<EShopDbContext>();
                    log.LogError(exception.Message);
                    await SeedAsync(eshopDbContext, loggerFactory, retryForAvailability);
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
                    Name = "IPhone - Black",
                    ImageFile = "https://cdn.pixabay.com/photo/2013/07/12/18/39/smartphone-153650_960_720.png",
                    UnitPrice = 150,
                    UnitsInStock = 10
                },
                new Product()
                {
                    Name = "PC Monitor",
                    ImageFile = "https://cdn.pixabay.com/photo/2012/04/13/15/03/monitor-32743_960_720.png",
                    UnitPrice = 200,
                    UnitsInStock = 5
                },
                new Product()
                {
                    Name = "Mac Collection",
                    ImageFile = "https://cdn.pixabay.com/photo/2017/05/11/11/15/workplace-2303851_960_720.jpg",
                    UnitPrice = 900,
                    UnitsInStock = 6
                },
                new Product()
                {
                    Name = "Keyboard",
                    ImageFile = "https://cdn.pixabay.com/photo/2013/07/13/11/50/computer-158770_960_720.png",
                    UnitPrice = 1000,
                    UnitsInStock = 20
                }
            };

            eshopDbContext.Products.AddRange(products);
            await eshopDbContext.SaveChangesAsync();
        }
    }
}
