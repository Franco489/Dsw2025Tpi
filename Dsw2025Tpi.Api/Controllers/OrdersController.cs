using Dsw2025Tpi.Application.Dtos;
using Dsw2025Tpi.Application.Exceptions;
using Dsw2025Tpi.Application.Services;
using Dsw2025Tpi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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

    //[HttpPost()]
    //public async Task<IActionResult> CreateOrder([FromBody] OrderModel.Request request)
    //{
    //    try
    //    {
    //        var order = await _service.CreateOrder(request);
    //        return Ok(order);
    //    }
    //    catch (EntityNotFoundException ex)
    //    {
    //        return NotFound(new { message = ex.Message });
    //    }
    //    catch (DuplicatedEntityException ex)
    //    {
    //        return BadRequest(new { message = ex.Message });
    //    }
    //    catch (ApplicationException)
    //    {
    //        return BadRequest("No se pudo crear la oren");
    //    }
    //}
}



