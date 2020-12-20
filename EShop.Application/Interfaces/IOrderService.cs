using EShop.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Interfaces
{
    public interface IOrderService
    {
        Task<OrderModel> CheckOut(OrderModel orderModel);
        Task<OrderModel> GetOrderById(int id);
        Task<IEnumerable<OrderModel>> GetOrderList();
    }
}
