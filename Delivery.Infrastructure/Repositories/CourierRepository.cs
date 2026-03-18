using Delivery.Application.Interfaces;
using Delivery.Domain.Entities;
using Delivery.Domain.Interfaces.ICourier;
using Delivery.Infrastructure.Data;

namespace Delivery.Infrastructure.Repositories;

public class CourierRepository : ICourierRepository
{
    private readonly IAppDbContext _context;
    
    public CourierRepository(IAppDbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Courier> GetAllCouriers(int pageNumber = 1, int pageSize = 10)
    {
        return _context.Couriers.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    }

    public Courier? GetCourierById(Guid id)
    {
        return _context.Couriers.FirstOrDefault(c => c.Id == id);
    }

    public async Task AddCourierAsync(Courier courier, CancellationToken cancellationToken)
    {
        await _context.Couriers.AddAsync(courier);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public Task UpdateCourierInformation(Courier courier, CancellationToken cancellationToken)
    {
        _context.Couriers.Update(courier);
        return _context.SaveChangesAsync(cancellationToken);
    }
}