using Application.Dtos.Orders;
using Domain.Entities;
using Infrastructure.Data.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
    public interface IOrdersRepository
    {
        Task<PagedList<Order>> GetAllAsync();
        Task<PagedList<Order>> GetOrdersByCriteriaAsync(OrderPagedRequestDto orderPagedRequestDto);
        Task<Order> AddAsync(Order order);
    }
}
