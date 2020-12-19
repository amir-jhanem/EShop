using EShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Interfaces
{
    public interface IProductPageService
    {
        Task Create(ProductViewModel product);
        Task Delete(ProductViewModel product);
        Task<ProductViewModel> GetProductById(int id);
        Task<IEnumerable<ProductViewModel>> GetProducts(string productName);
        Task Update(ProductViewModel product);
    }
}
