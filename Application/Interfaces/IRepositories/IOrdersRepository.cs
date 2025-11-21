using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<IEnumerable<Order>> GetOrdersByStatusFromToAsync(DateTime? From, DateTime? To);
        Task<Order> AddAsync(Order order);
    }
}
