using Delivery.Domain.Entities;

namespace Delivery.Domain.Interfaces;

public interface IOrderRepository
{
    Order? GetOrderById(Guid id);
    Task AddOrderAsync(Order order, CancellationToken cancellationToken);
    Task UpdateOrder(Order order, CancellationToken cancellationToken);
    Task DeleteOrderAsync(Order order, CancellationToken cancellationToken);
}