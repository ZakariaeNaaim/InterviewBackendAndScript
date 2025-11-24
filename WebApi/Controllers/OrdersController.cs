using App.WebApi.Wrappers;
using Application.Dtos;
using Application.Dtos.Orders;
using Application.Interfaces.IServices;
using Infrastructure.Data.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.ModelBinding;
using System.Web.Services.Description;

namespace WebApi.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService )
        {
            _ordersService = ordersService;
        }

        [HttpPost]
        [Route("search")]
        public async Task<AppResult<PagedList<OrderDto>>> SearchOrders([FromBody] OrderPagedRequestDto request)
        {
            var result = await _ordersService.GetOrdersByCriteriaAsync(request);

            return AppResult<PagedList<OrderDto>>.Ok(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<AppResult<PagedList<OrderDto>>> Get()
        {
            return AppResult<PagedList<OrderDto>>.Ok(await _ordersService.Get());
        }

        [HttpPost]
        [Route("")]
        public async Task<AppResult<OrderDto>> Post([FromBody] OrderDto orderDto)
        {
            return AppResult<OrderDto>.Ok(await _ordersService.CreateOrder(orderDto));
        }
    }
}
