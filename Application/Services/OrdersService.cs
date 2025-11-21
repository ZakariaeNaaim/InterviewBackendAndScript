using Application.Dtos;
using Application.Exceptions;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Application.Mappers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _orderRepo;

        public OrdersService(IOrdersRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<List<OrderDto>> Get()
        {
            IEnumerable<Order> orders = await _orderRepo.GetAllAsync(); 
            return orders?.Select(OrderToOrderDtoMapper.Map).ToList();
        }

        public async Task<Order> CreateOrder(OrderDto orderDto)
        {
            if (orderDto == null)
                throw new ValidationException(nameof(orderDto));

            var order = OrderDtoToOrderMapper.Map(orderDto);

            return await _orderRepo.AddAsync(order);
        }

        public async Task<List<OrderDto>> GetOrdersByStatusFromTo(DateTime? from, DateTime? to)
        {
            var orders = await _orderRepo.GetOrdersByStatusFromToAsync(from, to);
            return orders.Select(OrderToOrderDtoMapper.Map).ToList();
        }
    }
}
