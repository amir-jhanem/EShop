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
                // Phone
                new Product()
                {
                    Name = "uPhone X",
                    ImageFile = "https://i.imgur.com/Te1vdCG.png",
                    UnitPrice = 295,
                    UnitsInStock = 10
                },
                new Product()
                {
                    Name = "uPhone X",
                    ImageFile = "https://i.imgur.com/Te1vdCG.png",
                    UnitPrice = 295,
                    UnitsInStock = 10
                },
                new Product()
                {
                    Name = "uPhone X",
                    ImageFile = "https://i.imgur.com/Te1vdCG.png",
                    UnitPrice = 295,
                    UnitsInStock = 10
                },
                new Product()
                {
                    Name = "uPhone X",
                    ImageFile = "https://i.imgur.com/Te1vdCG.png",
                    UnitPrice = 295,
                    UnitsInStock = 10
                },
                new Product()
                {
                    Name = "uPhone X",
                    ImageFile = "https://i.imgur.com/Te1vdCG.png",
                    UnitPrice = 295,
                    UnitsInStock = 10
                },
                new Product()
                {
                    Name = "uPhone X",
                    ImageFile = "https://i.imgur.com/Te1vdCG.png",
                    UnitPrice = 295,
                    UnitsInStock = 10
                },
                new Product()
                {
                    Name = "uPhone X",
                    ImageFile = "https://i.imgur.com/Te1vdCG.png",
                    UnitPrice = 295,
                    UnitsInStock = 10
                },
                new Product()
                {
                    Name = "uPhone X",
                    ImageFile = "https://i.imgur.com/Te1vdCG.png",
                    UnitPrice = 295,
                    UnitsInStock = 10
                }
            };

            eshopDbContext.Products.AddRange(products);
            await eshopDbContext.SaveChangesAsync();
        }
    }
}
