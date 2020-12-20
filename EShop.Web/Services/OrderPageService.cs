using AutoMapper;
using EShop.Application.Interfaces;
using EShop.Web.Interfaces;
using EShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Web.Services
{
    public class OrderPageService : IOrderPageService
    {
        private readonly IOrderService _orderAppService;

        private readonly IMapper _mapper;

        public OrderPageService(IOrderService orderAppService, IMapper mapper)
        {
            _orderAppService = orderAppService ?? throw new ArgumentNullException(nameof(orderAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<OrderViewModel>> GetOrders()
        {
            var list = await _orderAppService.GetOrderList();
            var mappedByName = _mapper.Map<IEnumerable<OrderViewModel>>(list);
            return mappedByName;
        }
    }
}
