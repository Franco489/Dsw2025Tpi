using Microsoft.AspNetCore.Mvc;
using Dsw2025Tpi.Application.Dtos;
using Dsw2025Tpi.Application.Services;
using Dsw2025Tpi.Application.Exceptions;

namespace Dsw2025Tpi.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly OrdersManagementService _service;
    public OrdersController(OrdersManagementService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<OrderModel.Response>> CreateOrder([FromBody] OrderModel.Request reqest)
    {
        try
        {
            var order = await _service.CreateOrderAsync(reqest);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderModel.Response>> GetOrderById(Guid id)
    {
        var order = await _service.GetOrderByIdAsync(id);
        if (order == null)
            return NotFound();

        return Ok(order);
    }
}


}
