using Dsw2025Tpi.Application.Exceptions;
using Dsw2025Tpi.Domain.Interfaces;
using Dsw2025Tpi.Domain.Entities;
using Dsw2025Tpi.Application.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Dsw2025Tpi.Application.Services;

public class ProductsManagementService
{
    private readonly IRepository _repository;

    public ProductsManagementService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductModel.Response?> GetProductById(Guid id)
    {
        var product = await _repository.GetById<Product>(id);
        if (product == null) throw new Exception("No se encontró el producto solicitado.");
        return new ProductModel.Response(
            product.Sku,
            product.Name,
            product.CurrentUnitPrice,
            product.Descripcion,
            product.StockQuantity,
            product.InternalCode,
            product.productId
        );
    }

    public async Task<IEnumerable<ProductModel.Response>?> GetProducts()
    {
        return (await _repository
            .GetFiltered<Product>(p => p.IsActive))?
            .Select(p => new ProductModel.Response(p.Sku, p.Name,
            p.CurrentUnitPrice, p.Descripcion, p.StockQuantity, p.InternalCode, p.productId));
    }

    public async Task<ProductModel.Response> AddProduct(ProductModel.Request request)
    {
        if (string.IsNullOrWhiteSpace(request.Sku) ||
            string.IsNullOrWhiteSpace(request.Name) ||
            request.Price < 0)
        {
            throw new ArgumentException("Valores para el producto no válidos");
        }

        var exist = await _repository.First<Product>(p => p.Sku == request.Sku);
        if (exist != null) throw new DuplicatedEntityException($"Ya existe un producto con el Sku {request.Sku}");
        var product = new Product(request.Sku, request.Name, request.Price, request.Descripcion, request.StockQuantity, request.InternalCode);
        await _repository.Add(product);
        return new ProductModel.Response(product.Sku, product.Name,
            product.CurrentUnitPrice, product.Descripcion, product.StockQuantity, product.InternalCode, product.productId);
    }

    public async Task<ProductModel.Response> UpdateProduct(ProductModel.Request request)
    {
        var exist = await _repository.First<Product>(p => p.productId == request.productId);
        if (exist == null) throw new EntityNotFoundException("No existe ese producto");

        exist.Sku = request.Sku;
        exist.Name = request.Name;
        exist.CurrentUnitPrice = request.Price;
        exist.Descripcion = request.Descripcion;
        exist.StockQuantity = request.StockQuantity;
        exist.InternalCode = request.InternalCode;

        await _repository.Update(exist);

        return new ProductModel.Response(exist.Sku, exist.Name,exist.CurrentUnitPrice,exist.Descripcion,exist.StockQuantity,exist.InternalCode,exist.productId);
    }
}

