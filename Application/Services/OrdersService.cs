using Application.Dtos;
using Application.Dtos.Orders;
using Application.Exceptions;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Application.Mappers;
using Domain.Entities;
using Infrastructure.Data.Pagination;
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

        public async Task<PagedList<OrderDto>> Get()
        {
            var pagedOrders = await _orderRepo.GetAllAsync().ConfigureAwait(false);

            return pagedOrders.Convert(OrderToOrderDtoMapper.Map);
        }
        public async Task<PagedList<OrderDto>> GetOrdersByCriteriaAsync(OrderPagedRequestDto request)
        {
            var pagedOrders = await _orderRepo.GetOrdersByCriteriaAsync(request).ConfigureAwait(false);

            return pagedOrders.Convert(OrderToOrderDtoMapper.Map);
        }

        public async Task<OrderDto> CreateOrder(OrderDto orderDto)
        {
            if (orderDto == null)
                throw new ValidationException(nameof(orderDto));

            var order = OrderDtoToOrderMapper.Map(orderDto);

            return OrderToOrderDtoMapper.Map(await _orderRepo.AddAsync(order).ConfigureAwait(false));
        }
    }
}
