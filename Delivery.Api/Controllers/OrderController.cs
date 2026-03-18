using Delivery.Application.DTOs.OrderDtos;
using Delivery.Application.Interfaces.IOrder;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderDto dto, CancellationToken cancellationToken)
    {
        var result = await _orderService.CreateOrderAsync(dto, cancellationToken);
        return Created($"/api/orders/{result.Id}", result);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetOrdersById(Guid id)
    {
        var result = _orderService.GetOrderById(id);
        return Ok(result);
    }

    [HttpPut("{id:guid}/status")]
    public async Task<IActionResult> UpdateOrderStatusAsync(Guid id, [FromBody] UpdateOrderStatusDto dto,
        CancellationToken cancellationToken)
    {
        await _orderService.UpdateOrderStatusAsync(id, dto.NewStatus, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteOrder(Guid id, CancellationToken cancellationToken)
    {
        await _orderService.DeleteOrderAsync(id, cancellationToken);
        return NoContent();
    }
}