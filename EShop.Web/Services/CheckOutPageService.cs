using AutoMapper;
using EShop.Application.Interfaces;
using EShop.Application.Models;
using EShop.Web.Interfaces;
using EShop.Web.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EShop.Web.Services
{
    public class CheckOutPageService : ICheckOutPageService
    {
        private readonly IOrderService _orderAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<CheckOutPageService> _logger;

        public CheckOutPageService(IOrderService orderAppService, IMapper mapper, ILogger<CheckOutPageService> logger)
        {
            _orderAppService = orderAppService ?? throw new ArgumentNullException(nameof(orderAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<OrderModel> CheckOut(OrderViewModel order, string userId)
        {
            var mappedOrderModel = _mapper.Map<OrderModel>(order);
            mappedOrderModel.UserId = userId;
            return await _orderAppService.CheckOut(mappedOrderModel);
        }
    }
}
