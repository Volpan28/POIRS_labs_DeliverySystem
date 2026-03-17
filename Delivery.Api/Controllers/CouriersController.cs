using Delivery.Application.DTOs.CourierDtos;
using Delivery.Application.Interfaces.AICourier;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CouriersController : ControllerBase
{
    private readonly ICourierService _courierService;

    public CouriersController(ICourierService courierService)
    {
        _courierService = courierService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourier([FromBody] CreateCourierDto dto)
    {
        var result = await _courierService.CreateCourierAsync(dto);
        return Created($"/api/couriers/{result.Id}", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCouriers()
    {
        var result = _courierService.GetAllCouriers();
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetCourierById(Guid id)
    {
        var result = _courierService.GetCourierById(id);
        return Ok(result);
    }
}