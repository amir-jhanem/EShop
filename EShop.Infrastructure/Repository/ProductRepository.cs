using EShop.Core.Entities;
using EShop.Core.Repositories;
using EShop.Infrastructure.Data;
using EShop.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(EShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetProductListAsync()
        {
            return await GetAllAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByNameAsync(string productName)
        {
            return await GetAsync(x => x.Name.ToLower().Contains(productName.ToLower()));
        }
    }
}
