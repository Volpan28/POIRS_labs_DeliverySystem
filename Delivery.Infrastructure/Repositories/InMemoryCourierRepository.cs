using System.Collections.Concurrent;
using Delivery.Domain.Entities;
using Delivery.Domain.Interfaces.ICourier;

namespace Delivery.Infrastructure.Repositories;

public class InMemoryCourierRepository : ICourierRepository
{
    private readonly ConcurrentDictionary<Guid, Courier> _couriers = new ConcurrentDictionary<Guid, Courier>();
    
    public IEnumerable<Courier> GetAllCouriers()
    {
        return _couriers.Values.ToList();
    }

    public Courier? GetCourierById(Guid id)
    {
        _couriers.TryGetValue(id, out var courier);
        return courier;
    }

    public Task AddCourierAsync(Courier courier)
    {
        _couriers.TryAdd(courier.Id, courier);
        return Task.CompletedTask;
    }

    public Task UpdateCourierInformation(Courier courier)
    {
        _couriers.TryUpdate(courier.Id, courier, courier);
        return Task.CompletedTask;
    }
}