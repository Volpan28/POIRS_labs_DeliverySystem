using Delivery.Domain.Entities;

namespace Delivery.Domain.Interfaces.ICourier;

public interface ICourierRepository
{
    IEnumerable<Courier> GetAllCouriers(int pageNumber = 1, int pageSize = 10);
    Courier? GetCourierById(Guid id);
    Task AddCourierAsync(Courier courier, CancellationToken cancellationToken);
    Task UpdateCourierInformation(Courier courier, CancellationToken cancellationToken);
}