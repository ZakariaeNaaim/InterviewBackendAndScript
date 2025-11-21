using Application.Interfaces.IRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infrastructure.Data
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly AppDbContext _dbContext;
        public OrdersRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Orders.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatusFromToAsync(DateTime? from, DateTime? to)
        {
            try
            {
                return await _dbContext.Orders
                           .Where(o => o.OrderDate >= from && o.OrderDate <= to)
                           .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Order> AddAsync(Order order)
        {
            try
            {
                _dbContext.Orders.Add(order);
                await _dbContext.SaveChangesAsync();
                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
