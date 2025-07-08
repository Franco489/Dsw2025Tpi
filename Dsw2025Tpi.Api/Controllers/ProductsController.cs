using Dsw2025Tpi.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dsw2025Tpi.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    ProductManagement _service;
    
    public ProductsController(ProductManagement service)
    {
        _service = service;
    }

    [HttpGet("{id:guid}", Name = "GetProductById")]
    public async Task<IActionResult> GetProductByIdAsync(Guid id)
    {
            var result = await _service.GetProductById(id);
        if (result == null)
        {
            return NotFound();
        }
            return Ok(result);

      
    }








}
