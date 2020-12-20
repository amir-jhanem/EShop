using EShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Interfaces
{
    public interface IOrderPageService
    {
        Task<IEnumerable<OrderViewModel>> GetOrders();
    }
}
