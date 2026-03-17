using Delivery.Application.DTOs.CourierDtos;
using Delivery.Domain.Entities;

namespace Delivery.Application.Interfaces.AICourier;

public interface ICourierService
{
    Task<CourierResponseDto> CreateCourierAsync(CreateCourierDto dto);
    IEnumerable<CourierResponseDto> GetAllCouriers();
    CourierResponseDto GetCourierById(Guid id);
}