using Delivery.Domain.Enums;

namespace Delivery.Application.DTOs.CourierDtos;

public record CreateCourierDto(string Name, TransportType TransportType);