using Delivery.Domain.Entities;

namespace Delivery.Domain.Interfaces.ICourier;

public interface ICourierRepository
{
    IEnumerable<Courier> GetAllCouriers();
    Courier? GetCourierById(Guid id);
    Task AddCourierAsync(Courier courier);
    Task UpdateCourierInformation(Courier courier);
}