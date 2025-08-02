using Dsw2025Tpi.Application.Dtos;
using Dsw2025Tpi.Application.Exceptions;
using Dsw2025Tpi.Application.Interfaces;
using Dsw2025Tpi.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApplicationException = Dsw2025Tpi.Application.Exceptions.ApplicationException;

namespace Dsw2025Tpi.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersManagementService _service;

        public OrdersController(IOrdersManagementService service)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateOrder([FromBody] OrderModel.OrderRequest request)
        {
            if (request == null || request.OrderItems == null || request.OrderItems.Count == 0)
                return BadRequest("Datos de la orden inválidos o incompletos.");

            try
            {
                var order = await _service.CreateOrderAsync(request);
                return CreatedAtAction(nameof(GetOrderById), order.Id, order);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var orders = await _service.GetAllOrders();
                return Ok(orders);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }



        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            try
            {
                var order = await _service.GetOrderById(id);
                return Ok(order);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }



        [HttpPut("{id:guid}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateOrderStatus(Guid id, string newStatus)
        {
            try
            {
                var order = await _service.UpdateOrderStatus(id, newStatus);
                return Ok(order);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }


    }
}

