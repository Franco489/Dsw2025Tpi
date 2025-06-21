using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dsw2025Tpi.Data;
using Dsw2025Tpi.Domain.Interfaces;


namespace Dsw2025Tpi.Application.Controllers;

[ApiController]
public class ProductsController : ControllerBase
{
    readonly IRepository _persistencia;



    public ProductsController(IRepository persistencia)
    {
        _persistencia = persistencia;
    }

    [HttpPost("api/CreateProduct/{sku},{name},{precio},{codigoInterno},{descripcion},{CantidadStock}")]

    public IActionResult CreateProduct(string sku, decimal precio, string codigoInterno, string descripcion)
    {
        var productos = _persistencia.Add();

        if (productos == null || !productos.Any()) return NoContent();
        return Ok(productos);
    }



    [HttpGet()]
    public async Task<IActionResult> GetProducts()
    {
        var products = await GetList().GetProducts();
        if (products == null || !products.Any()) return NoContent();
        return Ok(products);
    }

    [HttpGet("api/products")]
    public IActionResult GetProduct(string sku)
    {
        
        var producto = _persistencia.GetAll();

        if (producto == null) return NotFound();


        return Ok(producto);
    }

    [HttpGet("api/products/{sku}")]
    public async Task<IActionResult> DeleteProduct(string sku)
    {
        var producto = await _persistencia._products.FirstOrDefault(p => p.Sku == sku); //POR QUE PINGO NO ANDAAAAA
        if (producto == null)
        {
            return NotFound();
        }
        await _persistencia.Sku.isActive(false);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(string sku)
    {
        var producto = await _persistencia._products.FirstOrDefault(p => p.Sku == sku);
        if (producto == null)
        {
            return NotFound();
        }
        return BadRequest();
    }

}








