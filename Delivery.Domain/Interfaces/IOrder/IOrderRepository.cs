using Delivery.Domain.Entities;

namespace Delivery.Domain.Interfaces;

public interface IOrderRepository
{
    IEnumerable<Courier> GetAllOrders();
    Order GetOrderById(Guid id);
    void AddOrder(Order order);
    void UpdateOrder(Order order);
}