using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers
{
    public static class OrderToOrderDtoMapper
    {
        public static OrderDto Map(Order order)
        {
            if (order == null) return null;

            return new OrderDto
            {
                OrderId= order.Id,
                Quantity = order.Quantity,
                UnitPrice = order.UnitPrice,
                TotalPrice = order.Quantity * order.UnitPrice,
                OrderDate = order.OrderDate,
                Status = order.Status,
                ProductId = order.ProductId,
                CustomerId = order.CustomerId
            };
        }
    }
}
