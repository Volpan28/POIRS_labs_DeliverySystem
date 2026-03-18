using Delivery.Application.DTOs.OrderDtos;
using Delivery.Domain.Entities;
using Delivery.Domain.Enums;

namespace Delivery.Application.Interfaces.IOrder;

public interface IOrderService
{
    Task<OrderResponseDto> CreateOrderAsync(CreateOrderDto createOrderDto, CancellationToken cancellationToken);
    OrderResponseDto GetOrderById(Guid orderId);
    Task UpdateOrderStatusAsync(Guid orderId, DeliveryStatus status, CancellationToken cancellationToken);
    Task DeleteOrderAsync(Guid Id, CancellationToken cancellationToken);
}