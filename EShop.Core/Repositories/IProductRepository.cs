using EShop.Core.Entities;
using EShop.Core.Repositories.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductListAsync();
        Task<IEnumerable<Product>> GetProductByNameAsync(string productName);
    }
}
