using Delivery.Application.DTOs.CourierDtos;
using Delivery.Application.Exceptions;
using Delivery.Application.Interfaces.AICourier;
using Delivery.Domain.Entities;
using Delivery.Domain.Interfaces.ICourier;

namespace Delivery.Application.Services;

public class CourierService : ICourierService
{
    private readonly ICourierRepository _repo;

    public CourierService(ICourierRepository repository)
    {
        _repo = repository;
    }

    public async Task<CourierResponseDto> CreateCourierAsync(CreateCourierDto dto, CancellationToken cancellationToken)
    {
        var courier = new Courier(dto.Name, dto.TransportType);
        
        await _repo.AddCourierAsync(courier, cancellationToken);
        return new CourierResponseDto(courier.Id, courier.IsActive);
    }

    public IEnumerable<CourierResponseDto> GetAllCouriers(int PageNumber = 1, int PageSize = 10)
    {
        var couriers = _repo.GetAllCouriers(PageNumber, PageSize);
        return couriers.Select(c => new CourierResponseDto(c.Id, c.IsActive));
    }

    public CourierResponseDto GetCourierById(Guid id)
    {
        var courier = _repo.GetCourierById(id);
        if (courier is null)
        {
            throw new NotFoundException($"Courier with id {id} not found");
        }
        return new CourierResponseDto(courier.Id, courier.IsActive);
    }
}