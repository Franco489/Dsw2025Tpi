using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dsw2025Tpi.Application.Services;
using Dsw2025Tpi.Application.Dtos;
using Dsw2025Tpi.Application.Exceptions;

namespace Dsw2025Tpi.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly ProductsManagementService _service;

    public ProductsController(ProductsManagementService service)
    {
        _service = service;
    }

    [HttpGet()]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _service.GetProducts();
        if (products == null || !products.Any()) return NoContent();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        try
        {
            var product = await _service.GetProductById(id);
            return Ok(product);
        }
        catch (EntityNotFoundException nf)
        {
            return NotFound(nf.Message);
        }
    }

    [HttpPost()]
    public async Task<IActionResult> AddProduct([FromBody] ProductModel.Request request)
    {
        try
        {
            var product = await _service.AddProduct(request);
            return Created($"api/products{product.Id}",product);
        }
        catch (DuplicatedEntityException de)
        {
            return BadRequest(de.Message);
        }
        catch (ApplicationException ae)
        {
            return BadRequest(ae.Message);
        }
        
    }


    [HttpPut("{id}")]

    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody]ProductModel.Request request)
    {
        try
        {
            var product = await _service.UpdateProduct(id, request);
            return Ok(product);

        }
        catch(EntityNotFoundException nf)
        {
            return NotFound(nf.Message);
        }
        catch(DuplicatedEntityException ae)
        {
            return BadRequest(ae.Message);
        }
        catch(ApplicationException ae)
        {
            return BadRequest(ae.Message);
        }
    }


    [HttpPatch("{id}")]

    public async Task<IActionResult> DisableProducts(Guid id)
    {
        try
        {
            var product = await _service.DisableProduct(id);
            return NoContent();
        }
        catch(EntityNotFoundException nf)
        {
            return NotFound(nf.Message);
        }
    }
}








