using Delivery.Domain.Enums;

namespace Delivery.Application.DTOs.OrderDtos;

public record UpdateOrderStatusDto(DeliveryStatus NewStatus);