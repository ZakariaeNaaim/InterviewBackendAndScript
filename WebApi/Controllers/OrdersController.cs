using Application.Dtos;
using Application.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.ModelBinding;

namespace WebApi.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService )
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetOrdersByStatusFromTo([QueryString] DateTime? from, [QueryString] DateTime? to)
        {
            if (!from.HasValue || !to.HasValue)
                return BadRequest("From and To parameters are required.");

            return Ok(await _ordersService.GetOrdersByStatusFromTo(from,to));
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _ordersService.Get());
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] OrderDto orderDto)
        {
            if(orderDto == null)
                return BadRequest("Order data is required.");

            return Ok(await _ordersService.CreateOrder(orderDto));
        }
    }
}
