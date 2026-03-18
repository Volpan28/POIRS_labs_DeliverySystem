using Delivery.Application.DTOs.OrderDtos;
using Delivery.Application.Exceptions;
using Delivery.Application.Interfaces.IOrder;
using Delivery.Domain.Entities;
using Delivery.Domain.Enums;
using Delivery.Domain.Interfaces;

namespace Delivery.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repo;
    public OrderService(IOrderRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<OrderResponseDto> CreateOrderAsync(CreateOrderDto dto, CancellationToken cancellationToken)
    {
        var order = new Order(dto.Description, dto.Weight, dto.Price, dto.ClientId);
        await _repo.AddOrderAsync(order, cancellationToken);
        return new OrderResponseDto(order.Id, order.Description, order.Status, order.ClientId);
    }

    public OrderResponseDto GetOrderById(Guid orderId)
    {
        var order = _repo.GetOrderById(orderId);

        if (order == null)
        {
            throw new NotFoundException($"Order with id {orderId} not found");
        }
        
        return new OrderResponseDto(order.Id, order.Description, order.Status, order.ClientId);
    }
    
    public async Task DeleteOrderAsync(Guid orderId, CancellationToken cancellationToken)
    {
        var order = _repo.GetOrderById(orderId);
        if (order == null)
        {
            throw new NotFoundException($"Order with id {orderId} not found");
        }
        
        await _repo.DeleteOrderAsync(order, cancellationToken);
    }

    public async Task UpdateOrderStatusAsync(Guid orderId, DeliveryStatus status, CancellationToken cancellationToken)
    {
        var order = _repo.GetOrderById(orderId);
        
        if (order == null)
        {
            throw new NotFoundException($"Order with id {orderId} not found");
        }
        
        switch (status)
        {
            case DeliveryStatus.InTransit:
                order.SetInTransit();
                break;
            case DeliveryStatus.Delivered:
                order.CompleteDelivery();
                break;
            case DeliveryStatus.Cancelled:
                order.CancelOrder();
                break; 
            default:
                throw new NotFoundException($"Status with name {status} not found");
        }
        
        await _repo.UpdateOrder(order, cancellationToken);
    }
}