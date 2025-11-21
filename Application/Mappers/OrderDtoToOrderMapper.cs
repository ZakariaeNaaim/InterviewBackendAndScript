using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class OrderDtoToOrderMapper
    {
        public static Order Map(OrderDto orderDto)
        {
            if (orderDto == null) return null;

            return new Order
            {
                Id = orderDto.OrderId,
                Quantity = orderDto.Quantity,
                OrderDate = orderDto.OrderDate,
                Status = orderDto.Status,
                UnitPrice = orderDto.UnitPrice,
                ProductId = orderDto.ProductId,
                CustomerId = orderDto.CustomerId
            };
        }
    }
}
