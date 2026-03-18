using Delivery.Domain.Enums;

namespace Delivery.Application.DTOs.OrderDtos;

public record OrderResponseDto(Guid Id, string Description, DeliveryStatus Status, Guid CourierId);