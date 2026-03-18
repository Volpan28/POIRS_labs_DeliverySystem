using Delivery.Application.Interfaces;
using Delivery.Domain.Entities;
using Delivery.Domain.Interfaces;

namespace Delivery.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly IAppDbContext _context;
    
    public OrderRepository(IAppDbContext context)
    {
        _context = context;
    }
    
    public Order? GetOrderById(Guid id)
    {
        return _context.Orders.FirstOrDefault(o => o.Id == id);
    }

    public async Task AddOrderAsync(Order order, CancellationToken cancellationToken)
    {
        await _context.Orders.AddAsync(order, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
    
    public Task UpdateOrder(Order order, CancellationToken cancellationToken)
    {
        _context.Orders.Update(order);
        return _context.SaveChangesAsync(cancellationToken);
    }
    

    public async Task DeleteOrderAsync(Order order, CancellationToken cancellationToken)
    {
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync(cancellationToken);
    }
}