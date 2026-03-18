using Delivery.Application.DTOs.CourierDtos;
using Delivery.Domain.Entities;

namespace Delivery.Application.Interfaces.AICourier;

public interface ICourierService
{
    Task<CourierResponseDto> CreateCourierAsync(CreateCourierDto dto, CancellationToken cancellationToken);
    IEnumerable<CourierResponseDto> GetAllCouriers(int pageNumber = 1, int pageSize = 10);
    CourierResponseDto GetCourierById(Guid id);
}