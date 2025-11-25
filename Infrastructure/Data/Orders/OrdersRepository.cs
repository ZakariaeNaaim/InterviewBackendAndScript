using Application.Dtos.Orders;
using Application.Dtos.Pagination;
using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Data.Pagination;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Printing;
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

        public async Task<PagedList<Order>> GetAllAsync()
        {
            var query = _dbContext.Orders.OrderBy(o=> o.Id).AsNoTracking();
            return await PagedList<Order>.CreateAsync(query,1,10).ConfigureAwait(false);
        }

        public async Task<PagedList<Order>> GetOrdersByCriteriaAsync(OrderPagedRequestDto orderPagedRequestDto)
        {
            var query = _dbContext.Orders
                .Where(o => o.OrderDate >= orderPagedRequestDto.From && o.OrderDate <= orderPagedRequestDto.To)
                .OrderBy(o => o.OrderDate)
                .AsNoTracking();

            return await PagedList<Order>.CreateAsync(query, orderPagedRequestDto.Page, orderPagedRequestDto.PageSize).ConfigureAwait(false);
        }


        public async Task<Order> AddAsync(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return order;
        }
    }
}
