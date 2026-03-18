namespace Delivery.Application.DTOs.OrderDtos;

public record CreateOrderDto(string Description, double Weight, decimal Price, Guid ClientId);