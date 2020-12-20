using AutoMapper;
using EShop.Application.Interfaces;
using EShop.Application.Mapper;
using EShop.Application.Models;
using EShop.Core.Entities;
using EShop.Core.Interfaces;
using EShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAppLogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository, IAppLogger<OrderService> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<OrderModel>> GetOrderList()
        {
            var orderList = await _orderRepository.GetAllAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<OrderModel>>(orderList);
            return mapped;
        }

        public async Task<OrderModel> GetOrderById(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            var mapped = ObjectMapper.Mapper.Map<OrderModel>(order);
            return mapped;
        }

        public async Task<OrderModel> CheckOut(OrderModel orderModel)
        {
            ValidateOrder(orderModel);

            var mappedEntity = ObjectMapper.Mapper.Map<Order>(orderModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _orderRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - AspnetRunAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<OrderModel>(newEntity);
            return newMappedEntity;
        }

        private void ValidateOrder(OrderModel orderModel)
        {
            if (orderModel.Items.Count == 0)
            {
                throw new ApplicationException($"Order should have at least one item");
            }

            if (orderModel.Items.Count > 10)
            {
                throw new ApplicationException($"Order has maximum 10 items");
            }
        }
    }
}
