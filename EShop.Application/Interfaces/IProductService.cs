using EShop.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetProductList();
        Task<IEnumerable<ProductModel>> GetProductByName(string productName);
    }
}
