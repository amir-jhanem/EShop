using EShop.Application.Models;
using EShop.Web.ViewModels;
using System.Threading.Tasks;

namespace EShop.Web.Interfaces
{
    public interface ICheckOutPageService
    {
        Task<OrderModel> CheckOut(OrderViewModel order, string userName);
    }
}
