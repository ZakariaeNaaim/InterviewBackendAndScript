using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IOrdersService
    {
        Task<List<OrderDto>> Get();
        Task<List<OrderDto>> GetOrdersByStatusFromTo(DateTime? from,DateTime? to );
        Task<Order> CreateOrder(OrderDto order);
    }
}
