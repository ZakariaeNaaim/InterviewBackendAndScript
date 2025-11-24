using Application.Dtos;
using Application.Dtos.Orders;
using Domain.Entities;
using Infrastructure.Data.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IOrdersService
    {
        Task<PagedList<OrderDto>> Get();
        Task<PagedList<OrderDto>> GetOrdersByCriteriaAsync(OrderPagedRequestDto orderPagedRequestDto);
        Task<OrderDto> CreateOrder(OrderDto order);
    }
}
